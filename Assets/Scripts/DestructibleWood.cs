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
        breakableObject.OnDamage += CreateFire;
        breakableObject.OnBreak.AddListener(BurnObject);
    }

    private void OnDestroy()
    {
        breakableObject.OnDamage -= CreateFire;
        breakableObject.OnBreak.RemoveListener(BurnObject);
    }

    private void CreateFire(Vector3 damagePlace)
    {
        Instantiate(fireParticle, damagePlace, Quaternion.identity).GetComponent<ParticleSystem>();
    }

    private void BurnObject()
    {
        Instantiate(bigFireParticle, bigFireSpawnPoint.transform.position, Quaternion.identity);
    }
}
