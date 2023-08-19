using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region ProtectedVariables
    [SerializeField] protected Animator m_animator;

    [SerializeField] protected bool m_canMove = true;
    [SerializeField] protected bool m_canAct = true;
    [SerializeField] protected bool m_canJump = true;
    [SerializeField] protected bool m_canAttack = true;
    #endregion

    #region PrivateVariables
    [SerializeField] private float m_speed = 10f;
    [SerializeField] private float m_jumpPower = 7f;
    [SerializeField] private Rigidbody2D m_rigidbody;
    
    private bool m_isGround = true;
    private string Ground = "Ground";
    #endregion

    #region PublicMethod
    void Update()
    {
        CheckGround();
    }
    public void Move(int _dir)
    {
        if (m_canMove == false || m_canAct == false)
            return;

        //m_rigidbody.MovePosition(transform.position + new Vector3(_dir,0,0) * m_speed * Time.deltaTime);
        RaycastHit2D groundRay = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 0.6f, 1 << LayerMask.NameToLayer("Ground"));

        if (groundRay.collider == null)
        {
            transform.Translate(new Vector3(m_speed * _dir * Time.deltaTime, 0, 0));
        }

        transform.localScale = new Vector3(_dir, 1, 1);
    }

    public void Jump()
    {
        if (m_canJump == false || m_canAct == false)
            return;

        m_canJump = false;
        m_rigidbody.AddForce(m_jumpPower * Vector3.up, ForceMode2D.Impulse);
    }

    public void Hit(Vector2 _direciton, float _power)
    {
        m_canAct = false;

        m_rigidbody.velocity = _power * _direciton;

        m_animator.SetTrigger("Hit");
        m_animator.ResetTrigger("command1");
        m_animator.ResetTrigger("command2");
        m_animator.ResetTrigger("command3");
    }

    public abstract void Command1();

    public abstract void Command2();

    public abstract void Command3();

    public void SetCanActTrue()
    {
        m_canAct = true;
    }

    public  bool IsAnimationStateName(string name)
    {
        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName(name) == true)
            return true;

        return false;
    }
    #endregion

    #region PrivateMethod
    private void CheckGround()
    {
        if(m_rigidbody.velocity.y > 0)
        {
            return;
        }

        m_isGround = false;

        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << LayerMask.NameToLayer("Ground"));

        if(ray.collider != null)
        {
            m_isGround = true;
            m_canJump = true;
        }
        else
        {
            Invoke(nameof(SetCanJumpFalse), 0.1f);
            m_isGround = false;
        }
    }

    private void SetCanJumpFalse()
    {
        m_canJump = false;
    }
    #endregion


}
