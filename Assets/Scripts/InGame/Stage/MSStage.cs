using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MSStage : MonoBehaviour
{
    #region PublicVariables
    public Vector2 m_player1InitialPos = Vector2.zero;
    public Vector2 m_player2InitialPos = Vector2.zero;
    #endregion

    #region PrivateVariables
    [SerializeField] private GameObject m_stagePrefab;

    private bool m_isStageStart = false;
    #endregion

    #region PublicMethod
    private void Update()
    {
        if (m_isStageStart == true)
        {
            m_stagePrefab.SetActive(true);
        }
        else
        {
            m_stagePrefab.SetActive(false);
        }
    }
    #endregion

    #region PrivateMethod
    #endregion
}
