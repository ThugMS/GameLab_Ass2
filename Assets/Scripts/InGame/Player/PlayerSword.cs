using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    private bool isHit = false;
    [SerializeField] private BoxCollider2D m_weakAttackCollider;
    [SerializeField] private BoxCollider2D m_strongAttackCollider;
    #endregion

    #region PublicMethod
    void Start()
    {

    }

    public void WeakAttack(float _weakAttackCoolTime)
    {
        Invoke("SetSwordTagWeakAttack", _weakAttackCoolTime / 3 * 1);
        Invoke("SetSwordTagNormal", _weakAttackCoolTime / 2 * 1);
    }

    public void StrongAttack(float _strongAttackCoolTime)
    {
        Invoke("SetSwordTagStrongAttack", _strongAttackCoolTime / 12 * 6);
        Invoke("SetSwordTagNormal", _strongAttackCoolTime / 12 * 9);
    }

    public void StopAttack()
    {
        SetSwordTagNormal();
        isHit = true;

        Invoke("ResetIsHit", 0.3f);
    }
    #endregion

    #region PrivateMethod
    private void SetSwordTagNormal()
    {
 

        m_weakAttackCollider.tag = "Normal";
        m_strongAttackCollider.tag = "Normal";

        m_weakAttackCollider.enabled = false;
        m_strongAttackCollider.enabled = false;
    }

    private void SetSwordTagWeakAttack()
    {
        if (isHit == true)
        {
            isHit = false;
            return;
        }
        m_weakAttackCollider.tag = "WeakAttack";

        m_weakAttackCollider.enabled = true;
    }

    private void SetSwordTagStrongAttack()
    {
        if (isHit == true)
        {
            isHit = false;
            return;
        }

        m_strongAttackCollider.tag = "StrongAttack";

        m_strongAttackCollider.enabled = true;
    }

    private void ResetIsHit()
    {
        isHit = false;
    }
    #endregion
}
