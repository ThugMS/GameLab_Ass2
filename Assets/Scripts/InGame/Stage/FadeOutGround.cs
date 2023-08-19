using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutGround : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    [SerializeField] private BoxCollider2D m_collider;
    [SerializeField] private Animator m_animator;
    #endregion

    #region PublicMethod
    #endregion

    #region PrivateMethod
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(1 << collision.gameObject.layer == 1 << LayerMask.NameToLayer("Player"))
        {
            m_animator.SetTrigger("Touch");
        }
    }
    #endregion
}
