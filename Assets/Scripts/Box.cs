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

    private void Awake()
    {
        breakableObject.ObjectDamaged += ChargeCube;
        breakableObject.ObjectBreaked += DestroyCube;
    }

    private void OnDestroy()
    {
        breakableObject.ObjectDamaged -= ChargeCube;
        breakableObject.ObjectBreaked -= DestroyCube;
    }

    private void ChargeCube()
    {
        Debug.Log("kjub obrywa");
    }

    private void DestroyCube()
    {
        Debug.Log("kjub zniszczony");
        var explosion = Instantiate(explosionParticle).GetComponent<ParticleSystem>();
        Instantiate(dustPile, pileSpawnPoint.position, Quaternion.identity, pileSpawnPoint.transform);
        modelToDestroy.SetActive(false);
        explosion.Play();
    }

}
