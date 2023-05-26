using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    private BreakableObject breakableObject;
    [SerializeField]
    private ParticleSystem explosionParticle;
    [SerializeField]
    private GameObject dustPile;
    [SerializeField]
    private GameObject modelToDestroy;
    [SerializeField]
    private ParticleSystem chargeParticle;

    private void Awake()
    {
        breakableObject.OnDamage += ChargeCube;
        breakableObject.OnBreak.AddListener(DestroyCube);
    }

    private void OnDestroy()
    {
        breakableObject.OnDamage -= ChargeCube;
        breakableObject.OnBreak.RemoveListener(DestroyCube);
    }

    private void ChargeCube(Vector3 _)
    {
        chargeParticle.Play();
    }

    private void DestroyCube()
    {
        explosionParticle.Play();
        modelToDestroy.SetActive(false);
        dustPile.SetActive(true);
    }

}
