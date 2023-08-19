using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSStage2 : MSStage
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    [SerializeField] private Thunder m_thunder;

    private float m_thunderCoolTime = 5.0f;
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
        m_thunder.ShowThunder();
    }

    private IEnumerator CheckCoolTime()
    {
        yield return new WaitForSeconds(m_thunderCoolTime);

        m_isReadyThunder = true;
    }
    #endregion
}
