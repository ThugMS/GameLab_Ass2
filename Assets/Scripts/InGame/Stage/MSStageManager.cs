using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSStageManager : MonoBehaviour
{
    public enum StageType {
        tutorial, stage1, stage2, stage3
    }

    #region PublicVariables
    public static MSStageManager instance;
    #endregion

    #region PrivateVariables
    [SerializeField] private MSStage[] m_stageList;

    private StageType m_stageType;
    #endregion

    #region PublicMethod
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StageStart(StageType _type)
    {
        m_stageList[(int)_type].StageStart();

        m_stageType = _type;
    }

    public void StageEnd()
    {
        m_stageList[(int) m_stageType].StageEnd();
    }
    #endregion

    #region PrivateMethod
    
    #endregion
}
