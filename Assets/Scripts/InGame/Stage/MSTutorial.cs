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
        base.StageStart();

        GameManager.instance.TutorialStart();
    }
    #endregion

    #region PrivateMethod
    #endregion
}
