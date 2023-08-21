using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePanel : MonoBehaviour
{
    #region PublicVariables
    public static StagePanel instance;
    #endregion

    #region PrivateVariables
    [SerializeField] private GameObject m_stagePanel;

    private MSStageManager.StageType m_stageType;
    #endregion

    #region PublicMethod
    private void Start()
    {
        m_stagePanel.SetActive(false);
    }

    public void ShowPanel()
    {
        m_stagePanel.SetActive(true);
    }

    public void HidePanel()
    {
        m_stagePanel.SetActive(false);
    }

    public void TutorialStage()
    {
        m_stageType = MSStageManager.StageType.tutorial;
        TutorialStartSetting();
    }

    public void Stage1()
    {
        m_stageType = MSStageManager.StageType.stage1;
        StageStartSetting();
    }

    public void Stage2()
    {
        m_stageType = MSStageManager.StageType.stage2;
        StageStartSetting();
    }

    public void Stage3()
    {
        m_stageType = MSStageManager.StageType.stage3;
        StageStartSetting();
    }
    #endregion

    #region PrivateMethod
    private void TutorialStartSetting()
    {
        CallStageStart();
        InitSetting();
    }

    private void StageStartSetting()
    {
        CallStageStart();
        InitSetting();
        StageSetting();
    }

    private void CallStageStart()
    {
        MSStageManager.instance.StageStart(m_stageType);
        m_stagePanel.SetActive(false);
    }

    private void InitSetting()
    {
        GameManager.instance.OffMainScreen();
        ESCMenu.g_pause = false;
    }

    private void StageSetting()
    {
        PlayerManager.instance.InitLife();
        GameManager.instance.GameStart();
    }
    #endregion
}
