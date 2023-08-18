using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Character
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    [SerializeField] private Animator counterEffect;
    #endregion

    #region PublicMethod
    public override void Command1() //WeakAttack
    {
        if (m_canAct == false || m_canAttack == false)
            return;

        m_animator.SetTrigger("command1");
    }

    public override void Command2() //StrongAttack
    {
        if (m_canAct == false || m_canAttack == false)
            return;

        m_canAct = false;
        m_animator.SetTrigger("command2");
    }

    public override void Command3() //Counter
    {
        if (m_canAct == false || m_canAttack == false)
            return;

        m_canAct = false;
        m_animator.SetTrigger("command3");
    }

    public void ShowCounterEffect()
    {
        
    }
    #endregion

    #region PrivateMethod
    #endregion

}
