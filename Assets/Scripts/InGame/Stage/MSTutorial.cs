using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSTutorial : MSStage
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    #endregion

    #region PublicMethod
    public override void StageStart()
    {
        m_stagePrefab.SetActive(true);
        MovePlayerStageInitialPos();
        CameraController.instance.ChangePlayer();

        GameManager.instance.TutorialStart();
    }

    public override void StageEnd()
    {
        m_stagePrefab?.SetActive(false);
    }
    #endregion

    #region PrivateMethod
    #endregion
}
