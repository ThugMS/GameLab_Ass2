using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StrongAttack : MonoBehaviour
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

    private float m_selfDiretion;
    #endregion

    #region PublicMethod
    private void Start()
    {

    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(m_basePos + new Vector2(m_strongAttackPosA.x * m_selfDiretion, m_strongAttackPosA.y), m_basePos + new Vector2(m_strongAttackPosB.x * m_selfDiretion, m_strongAttackPosB.y));
    }

    #region PrivateMethod
    private void FindStrongAttackEnemy()
    {
        m_selfDiretion = (int)transform.parent.localScale.x;

        m_basePos = transform.position;


        Collider2D col = Physics2D.OverlapArea(m_basePos + new Vector2(m_strongAttackPosA.x * m_selfDiretion, m_strongAttackPosA.y), m_basePos + new Vector2(m_strongAttackPosB.x * m_selfDiretion, m_strongAttackPosB.y), 1 << LayerMask.NameToLayer("Player"));

        if (col != null)
        {
            Character hitPlayer;
            col.TryGetComponent(out hitPlayer);

            if (hitPlayer != null)
            {
                CameraController.instance.SmashShake();

                EffectManager.instance.CallEffect(EffectManager.EEffectType.smash, transform.position + Vector3.right * m_selfDiretion * 3, m_selfDiretion);

                hitPlayer.Hit(new Vector2(m_selfDiretion * m_dir.x, m_dir.y).normalized, power);
                Debug.Log(new Vector2(m_selfDiretion * m_dir.x, m_dir.y).normalized);
            }
        }
    }
    #endregion
}
