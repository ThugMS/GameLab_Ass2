using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class WeakAttack : MonoBehaviour
{
    #region PublicVariables
    
    #endregion

    #region PrivateVariables
    private Vector2 m_basePos;

    [SerializeField] private Character m_player;
    [SerializeField] private Vector2 m_weakAttackPosA = new Vector2(2.9f, 0.35f);
    [SerializeField] private Vector2 m_weakAttackPosB = new Vector2(0.63f,  -0.35f);

    private int m_dir = 1;
    [SerializeField] private float power = 10f;
    #endregion

    #region PublicMethod
    private void Start()
    {
        
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(m_basePos + new Vector2(m_weakAttackPosA.x * m_dir, m_weakAttackPosA.y), m_basePos + new Vector2(m_weakAttackPosB.x * m_dir, m_weakAttackPosB.y));
    }

    #region PrivateMethod
    private void FindWeakAttackEnemy()
    {
        m_dir = (int)transform.parent.localScale.x;

        m_basePos = transform.position;

        Collider2D col = Physics2D.OverlapArea(m_basePos + new Vector2(m_weakAttackPosA.x * m_dir, m_weakAttackPosA.y), m_basePos + new Vector2(m_weakAttackPosB.x * m_dir, m_weakAttackPosB.y), 1 << LayerMask.NameToLayer("Player"));

        if(col != null)
        {
            Character hitPlayer;
            col.TryGetComponent(out hitPlayer);

            if(hitPlayer != null)
            {
                if (hitPlayer.IsAnimationStateName("counter"))
                {
                    Knight knightPlayer;
                    hitPlayer.TryGetComponent(out knightPlayer);
                    knightPlayer.ShowCounterEffect();

                    m_player.Hit(new Vector2(-m_dir, 0), power);
                }
                else
                {
                    hitPlayer.Hit(new Vector2(m_dir, 0), power);
                }
            }
        }
    }
    #endregion
}
