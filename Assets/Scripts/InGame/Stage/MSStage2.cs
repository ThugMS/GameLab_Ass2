using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSStage2 : MSStage
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    [SerializeField] private Thunder[] m_thunderList;

    private float m_thunderCoolTime = 3.0f;
    private bool m_isReadyThunder = false;
    #endregion

    #region PublicMethod
    private void Update()
    {
        if (m_isReadyThunder == true)
        {
            ShowThunder();
            m_isReadyThunder = false;
            StartCoroutine(nameof(CheckCoolTime));
        }
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(CheckCoolTime));
    }
    #endregion

    #region PrivateMethod
    private void ShowThunder()
    {
        for (int i = 0; i < m_thunderList.Length; i++)
        {
            m_thunderList[i].ShowThunder();
        }
            
    }

    private IEnumerator CheckCoolTime()
    {
        yield return new WaitForSeconds(m_thunderCoolTime);

        m_isReadyThunder = true;
    }
    #endregion
}
