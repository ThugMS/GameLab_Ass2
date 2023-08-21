using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    [SerializeField] GameObject m_meteorPrefab;

    [SerializeField] private float m_coolTime = 2.0f;
    [SerializeField] private bool m_canMeteor = true;

    private float m_x = 0;
    private float m_y = 20;
    #endregion

    #region PublicMethod
    private void Update()
    {
        if(m_canMeteor == true)
        {
            CreateMeteor();
            m_canMeteor=false;
            StartCoroutine(nameof(MeteorCoolTime));
        }
    }

    public void CreateMeteor()
    {
        m_x = Random.Range(-7f, 7f);
        
        Vector2 pos = new Vector2(m_x, m_y);

        GameObject obj = Instantiate(m_meteorPrefab, pos, Quaternion.identity);

        //Vector2 force = new Vector2(Random.Range(-50, 50), 0);

        //obj.GetComponent<Rigidbody2D>().AddForce(force);
    }
    #endregion

    #region PrivateMethod
    private IEnumerator MeteorCoolTime()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, m_coolTime));

        m_canMeteor = true;
    }
    #endregion
}
