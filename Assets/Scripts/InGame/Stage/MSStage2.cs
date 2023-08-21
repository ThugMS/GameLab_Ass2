using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSStage2 : MSStage
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    [SerializeField] private Thunder[] m_thunderList;
    [SerializeField] private GameObject m_thunderLight;

    private float m_thunderCoolTime = 6f;
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

    public override void StageEnd()
    {
        base.StageEnd();
        gameObject.SetActive(false);
    }

    public override void StageStart()
    {   
        gameObject.SetActive(true);
        base.StageStart();
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
        yield return new WaitForSeconds(m_thunderCoolTime - 1f);

        m_thunderLight.SetActive(true);

        yield return new WaitForSeconds(1f);

        m_isReadyThunder = true;
        m_thunderLight.SetActive(false);
    }
    #endregion
}
