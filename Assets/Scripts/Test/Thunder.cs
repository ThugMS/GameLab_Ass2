using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    private float m_coolTime = 3f;
    private float m_range = 25f;
    private float m_distance = 0f;

    [SerializeField] private Vector3 m_defalutPos = Vector3.zero;
    [SerializeField] private float m_height = 60f;
    [SerializeField] private float m_thunderHeight = 5f;
    [SerializeField] private Vector3 m_thunerPos = Vector3.zero;
    [SerializeField] private GameObject m_thunder;


    #endregion

    #region PublicMethod

    public void ShowThunder()
    {
        m_thunerPos = Vector3.zero;

        for (int i = 0; i < 20; i++)
        {
            Vector3 randomPos = Vector3.zero;
            randomPos.x = Random.Range(-m_range, m_range);
            randomPos.y = m_height;

            randomPos = FindPosition(randomPos);

            if (randomPos != Vector3.zero)
            {
                m_thunerPos = randomPos;
                break;
            }
        }

        m_thunerPos.y = m_thunderHeight;

        m_thunder.transform.position = m_thunerPos;
        m_thunder.SetActive(true);
    }
    #endregion

    #region PrivateMethod


    private Vector3 FindPosition(Vector3 _originPos)
    {
        RaycastHit2D ground = Physics2D.Raycast(_originPos, Vector3.down, 100f, 1 << LayerMask.NameToLayer("Ground"));

        if (ground.collider == null)
            return Vector3.zero;

        m_distance = ground.distance;

        return _originPos;
    }
    #endregion
}
