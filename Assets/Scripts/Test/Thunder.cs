using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    private float m_coolTime = 3f;

    [SerializeField] private Vector3 m_defalutPos = Vector3.zero;
    [SerializeField] private float height = 60f;
    #endregion

    #region PublicMethod
    #endregion

    #region PrivateMethod
    private void ShowThunder()
    {

    }

    private void FindPosition(Vector3 _originPos)
    {
        RaycastHit2D ground = Physics2D.Raycast(_originPos, Vector3.down, 100f, 1 << LayerMask.NameToLayer("Ground"));

        if (ground.collider == null)
            return;

        
    }
    #endregion
}
