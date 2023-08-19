using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    #region PublicVariables
    public bool m_isDead = false;
    public int m_life = 5;
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
    [SerializeField] private UIHeartContainer m_heartContainer;

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

    public void Dead()
    {
        m_life--;

        if(m_life <= 0)
        {
            m_isDead = true;
            m_life = 5;
        }

        if (m_heartContainer.PopAndReturnRevivalPossibility() == true)
           Revive();
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

    private void Revive()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector3 randomPos = Vector3.zero;
            randomPos.x = Random.Range(-30, 30);
            randomPos.y = 20;

            if (FindPosition(randomPos) == true)
            {
                transform.position = randomPos;
                m_rigidbody.velocity = Vector3.zero;
                return;
            }
        }

        transform.position = new Vector2(0, 20);
        m_rigidbody.velocity = Vector3.zero;
    }

    private bool FindPosition(Vector3 _originPos)
    {
        RaycastHit2D ground = Physics2D.Raycast(_originPos, Vector3.down, 100f, 1 << LayerMask.NameToLayer("Ground"));

        if (ground.collider == null)
            return false;

        return true; 
    }
    #endregion


}
