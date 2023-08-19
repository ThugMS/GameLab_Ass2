using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBottom : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    private Vector2 m_pos = Vector2.zero;
    [SerializeField] private Vector2 m_thunderRange = new Vector2(2f, 5f);
    [SerializeField] private Vector2 m_strongAttackPosB = new Vector2(0.63f, -0.5f);

    [SerializeField] private Vector2 m_dir = Vector3.zero;
    [SerializeField] private float power = 100f;
    #endregion

    #region PublicMethod
    #endregion

    #region PrivateMethod
    private void OnDrawGizmos()
    {
        m_pos = transform.position;
        m_pos.x += 1.2f;
        m_pos.y = m_pos.y - 2.5f;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(m_pos + m_thunderRange, m_pos - m_thunderRange);
    }

    private void ShowThunderParticle()
    {
        m_pos = transform.position;
        m_pos.y = m_pos.y - 5f;
        ParticleManager.instance.CallParticle(ParticleManager.ParticleType.thunder, m_pos, 1);
    }

    private void AttackPlayer()
    {
        m_pos = transform.position;
        m_pos.y = m_pos.y - 2.5f;

        Collider2D[] col = Physics2D.OverlapAreaAll(m_pos + m_thunderRange, m_pos - m_thunderRange, 1 << LayerMask.NameToLayer("Player"));

        for(int i=0;i<col.Length; i++)
        {
            if (col[i] != null)
            {
                Character hitPlayer;
                col[i].TryGetComponent(out hitPlayer);

                if (hitPlayer != null)
                {
                    Vector2 thunderToDirection = hitPlayer.transform.position - transform.position;
                    m_dir.y = 0.5f;

                    CameraController.instance.SmashShake();

                    hitPlayer.Hit(new Vector2(thunderToDirection.x, m_dir.y).normalized, power);
                }
            } 
        }
    }
    #endregion
}
