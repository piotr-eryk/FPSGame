using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWood : MonoBehaviour
{
    [SerializeField]
    private BreakableObject breakableObject;
    [SerializeField]
    private GameObject fireParticle;
    [SerializeField]
    private GameObject bigFireParticle;
    [SerializeField]
    private GameObject bigFireSpawnPoint;

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
        Instantiate(bigFireParticle, bigFireSpawnPoint.transform.position, Quaternion.identity);
    }
}
