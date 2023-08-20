using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMasterCommand2 : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    private Vector2 m_basePos;

    [SerializeField] private Character m_player;
    [SerializeField] private Vector2 m_strongAttackPosA = new Vector2(3.47f, 0.5f);
    [SerializeField] private Vector2 m_strongAttackPosB = new Vector2(0.63f, -0.5f);

    [SerializeField] private Vector2 m_dir = Vector3.zero;
    [SerializeField] private float power = 10f;

    private float m_selfDirection;
    #endregion

    #region PublicMethod
    #endregion

    #region PrivateMethod
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(m_basePos + new Vector2(m_strongAttackPosA.x * m_selfDirection, m_strongAttackPosA.y), m_basePos + new Vector2(m_strongAttackPosB.x * m_selfDirection, m_strongAttackPosB.y));
    }

    private void ShowCommand2()
    {
        m_selfDirection = (int)transform.parent.localScale.x;

        m_basePos = transform.position;


        Collider2D col = Physics2D.OverlapArea(m_basePos + new Vector2(m_strongAttackPosA.x * m_selfDirection, m_strongAttackPosA.y), m_basePos + new Vector2(m_strongAttackPosB.x * m_selfDirection, m_strongAttackPosB.y), 1 << LayerMask.NameToLayer("Player"));

        if (col != null)
        {
            Character hitPlayer;
            col.TryGetComponent(out hitPlayer);

            if (hitPlayer != null)
            {
                CameraController.instance.ThunderShake();

                ParticleManager.instance.CallParticle(ParticleManager.ParticleType.smash, transform.position + Vector3.right * m_selfDirection * 3, m_selfDirection);

                hitPlayer.Hit(new Vector2(m_selfDirection * m_dir.x, m_dir.y).normalized, power);
            }
        }
    }
    #endregion
}
