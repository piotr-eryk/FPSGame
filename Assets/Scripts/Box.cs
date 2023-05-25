using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    private BreakableObject breakableObject;
    [SerializeField]
    private GameObject explosionParticle;
    [SerializeField]
    private GameObject dustPile;
    [SerializeField]
    private GameObject modelToDestroy;
    [SerializeField]
    private Transform pileSpawnPoint;
    [SerializeField]
    private GameObject chargeParticle;

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
        Instantiate(chargeParticle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
    }

    private void DestroyCube()
    {
        var explosion = Instantiate(explosionParticle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        Instantiate(dustPile, pileSpawnPoint.position, Quaternion.identity, pileSpawnPoint.transform);
        modelToDestroy.SetActive(false);
        explosion.Play();
    }

}
