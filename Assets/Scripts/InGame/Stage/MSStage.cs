using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MSStage : MonoBehaviour
{
    #region PublicVariables
    public Vector2 m_player1InitialPos = Vector2.zero;
    public Vector2 m_player2InitialPos = Vector2.zero;
    #endregion

    #region ProtectedVariables
    [SerializeField] protected GameObject m_stagePrefab;

    protected GameObject m_stageObj;
    protected bool m_isStageStart = false;
    #endregion

    #region PublicMethod
    public virtual void StageStart()
    {   
        m_stageObj = Instantiate(m_stagePrefab, Vector3.zero, Quaternion.identity);
        m_stageObj.SetActive(true);

        //m_stagePrefab.SetActive(true);
        MovePlayerStageInitialPos();
        CameraController.instance.ChangePlayer();
    }

    public virtual void StageEnd()
    {
        //m_stagePrefab?.SetActive(false);
        Destroy(m_stageObj);
    }
    #endregion

    #region ProtectedMethod
    protected void MovePlayerStageInitialPos()
    {
        PlayerManager.instance.MovePlayerPosition(m_player1InitialPos, m_player2InitialPos);
    }
    #endregion
}
