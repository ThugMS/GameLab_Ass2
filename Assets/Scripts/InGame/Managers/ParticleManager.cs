using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Mathematics;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    #region PublicVariables
    public static ParticleManager instance;

    public enum ParticleType { 
        smash = 0, hit, thunder, death
    }
    #endregion

    #region PrivateVariables
    [SerializeField] private List<ParticleBundle> m_particles = new List<ParticleBundle>();
    #endregion

    #region PublicMethod
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void CallParticle(ParticleType _type, Vector2 _pos, float _rotation)
    {
        GameObject cur = GetParticleFromList(_type);
        ParticleBundle bundle = m_particles[(int)_type];

        if(cur == null)
        {
            cur = Instantiate(bundle.m_prefab, _pos, Quaternion.identity, transform) as GameObject;
            bundle.m_list.Add(cur);
            cur.transform.localScale = new Vector3(_rotation, 1, 1);
        }
        else
        {
            cur.transform.position = _pos;
            cur.transform.localScale = new Vector3(_rotation, 1, 1);
            cur.SetActive(true);
        }

        cur.GetComponent<ParticleSystem>().Play();
    }

    public void CallParticleDeath(ParticleType _type, Vector2 _pos, float _rotation)
    {
        GameObject cur = GetParticleFromList(_type);
        ParticleBundle bundle = m_particles[(int)_type];

        if (cur == null)
        {
            cur = Instantiate(bundle.m_prefab, _pos, Quaternion.identity, transform) as GameObject;
            cur.transform.rotation = Quaternion.Euler(new Vector3(0, 0, _rotation));

            Debug.Log(_rotation);

            bundle.m_list.Add(cur);

        }
        else
        {
            cur.transform.position = _pos;
            cur.transform.rotation = Quaternion.Euler(new Vector3(0, 0, _rotation));

            Debug.Log(_rotation);
            cur.SetActive(true);
        }

        cur.GetComponent<ParticleSystem>().Play();
    }
    #endregion

    #region PrivateMethod
    private GameObject GetParticleFromList(ParticleType _type)
    {
        GameObject cur = null;

        List<GameObject> curList = m_particles[(int)_type].m_list;

        for(int i=0;i<curList.Count;i++) {
            if (curList[i].activeSelf == false)
            {
                cur = curList[i];
                break;
            }
        }

        return cur;
    }
    #endregion
}
