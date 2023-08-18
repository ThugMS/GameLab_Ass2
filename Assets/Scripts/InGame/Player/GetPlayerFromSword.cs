using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerFromSword : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    [SerializeField] private GameObject m_player;
    #endregion

    #region PublicMethod
    public GameObject GetPlayer()
    {
        return m_player;
    }
    #endregion

    #region PrivateMethod
    #endregion
}
