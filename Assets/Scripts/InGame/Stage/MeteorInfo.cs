using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorInfo : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    [SerializeField] private Collider2D m_collider;
    [SerializeField] private ParticleSystem m_particle;
    #endregion

    #region PublicMethod
    private void Start()
    {
        m_particle.Play();
    }

    private void OnEnable()
    {
        m_particle.Play();
    }

    private void Update()
    {
        if(transform.position.y < -30f)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region PrivateMethod
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Character hitPlayer;
            collision.TryGetComponent(out hitPlayer);

            ParticleManager.instance.CallParticle(ParticleManager.ParticleType.hit, transform.position + Vector3.up, 1);

            hitPlayer.Stun();
        }
    }
    #endregion
}
