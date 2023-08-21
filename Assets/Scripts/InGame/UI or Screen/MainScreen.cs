using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainScreen : MonoBehaviour
{
    #region PublicVariables
    public static MainScreen instance;
    #endregion

    #region PrivateVariables
    [SerializeField] private GameObject m_stagePanel;
    [SerializeField] private TextMeshPro m_textMeshPro;
    #endregion

    #region PublicMethod
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }

        if (Input.anyKeyDown)
        {
            GameManager.instance.OnCharacterChoiceScreen();
            HideMainScreen();
        }
    }
    private void OnEnable()
    {
        
    }

    public void HideMainScreen()
    {
        gameObject.SetActive(false);
    }

    public void ShowMainScreen()
    {
        gameObject.SetActive(true);
    }
    #endregion

    #region PrivateMethod
    #endregion
}
