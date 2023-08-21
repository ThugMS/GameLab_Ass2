using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartUI : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    [SerializeField] private GameObject[] m_colorParts;
    [SerializeField] private GameObject[] m_colorShadowParts;
    [SerializeField] private Color[] m_color;
    #endregion

    #region PublicMethod
    public void SetColor()
    {
        for (int i = 0; i < m_colorParts.Length; i++)
        {
            m_colorParts[i].GetComponent<SpriteRenderer>().color = m_color[0];
        }

        for (int i = 0; i < m_colorShadowParts.Length; i++)
        {
            m_colorShadowParts[i].GetComponent<SpriteRenderer>().color = m_color[1];
        }
    }
    #endregion

    #region PrivateMethod
    #endregion
}
