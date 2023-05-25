using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricOrb : MonoBehaviour
{
    [SerializeField]
    private BreakableObject breakableObject;
    [SerializeField]
    private ParticleSystem orbParticle;
    [SerializeField]
    private GameObject bigExplosionParticle;
    [SerializeField]
    private Rigidbody rigidBody;

    private ParticleSystem.MainModule particleSettings;

    private void Awake()
    {
        breakableObject.OnDamage += DamageOrb;
        breakableObject.OnBreak += DestroyOrb;
        particleSettings = orbParticle.main;
    }

    private void OnDestroy()
    {
        breakableObject.OnDamage -= DamageOrb;
        breakableObject.OnBreak -= DestroyOrb;
    }

    private void DamageOrb(Vector3 _)
    {
        Debug.Log("kurwa");
        particleSettings = orbParticle.main;
        particleSettings.startLifetimeMultiplier *= 5f;
    }

    private void DestroyOrb()
    {
        Debug.Log("kurwa2");
        rigidBody.useGravity = true;
        Instantiate(bigExplosionParticle, rigidBody.transform.position, Quaternion.identity);
        orbParticle.Stop();
    }
}