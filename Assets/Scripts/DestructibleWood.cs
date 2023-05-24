using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWood : MonoBehaviour
{
    [SerializeField]
    private BreakableObject breakableObject;
    [SerializeField]
    private GameObject fireParticle;

    private void Awake()
    {
        breakableObject.ObjectDamaged += IgniteWood;
        breakableObject.ObjectBreaked += WoodOnFire;
    }

    private void OnDestroy()
    {
        breakableObject.ObjectDamaged -= IgniteWood;
        breakableObject.ObjectBreaked -= WoodOnFire;
    }

    private void IgniteWood(Vector3 damagePlace)//TODO: names
    {
        Instantiate(fireParticle, damagePlace, Quaternion.identity).GetComponent<ParticleSystem>();
    }

    private void WoodOnFire()
    {
        //var explosion = Instantiate(fireParticle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        //Instantiate(dustPile, pileSpawnPoint.position, Quaternion.identity, pileSpawnPoint.transform);
        //modelToDestroy.SetActive(false);
        //explosion.Play();
    }
}
