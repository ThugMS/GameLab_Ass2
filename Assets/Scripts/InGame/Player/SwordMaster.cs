using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SwordMaster : Character
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    #endregion

    #region PublicMethod
    public override void Move(int _dir)
    {
        if (m_canMove == false || m_canAct == false)
            return;

        //m_rigidbody.MovePosition(transform.position + new Vector3(_dir,0,0) * m_speed * Time.deltaTime);
        RaycastHit2D groundRay = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 0.6f, 1 << LayerMask.NameToLayer("Ground"));

        if (groundRay.collider == null)
        {
            transform.Translate(new Vector3(m_speed * _dir * Time.deltaTime, 0, 0));
        }

        transform.localScale = new Vector3(_dir*1.3f, 1.3f, 1.3f);
    }

    public override void Command1()
    {
        if (m_canAct == false || m_canAttack == false)
            return;

        m_canAct = true;
        m_animator.SetTrigger("command1");
    }

    public override void Command2()
    {
        if (m_canAct == false || m_canAttack == false)
            return;

        m_canAct = false;
        m_animator.SetTrigger("command2");
    }

    public override void Command3()
    {
        if (m_canAct == false || m_canAttack == false)
            return;

        m_canAct = false;
        m_animator.SetTrigger("command3");
    }

    #endregion

    #region PrivateMethod
    #endregion

}
