using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBottom : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    private Vector3 m_pos = Vector3.zero;
    #endregion

    #region PublicMethod
    #endregion

    #region PrivateMethod
    private void ShowThunderParticle()
    {
        m_pos = transform.position;
        m_pos.y = m_pos.y - 5f;
        ParticleManager.instance.CallParticle(ParticleManager.ParticleType.thunder, m_pos, 1);
    }
    #endregion
}
