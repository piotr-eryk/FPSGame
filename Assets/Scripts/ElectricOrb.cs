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
        breakableObject.OnBreak.AddListener(DestroyOrb);
        particleSettings = orbParticle.main;
    }

    private void OnDestroy()
    {
        breakableObject.OnDamage -= DamageOrb;
        breakableObject.OnBreak.RemoveListener(DestroyOrb);
    }

    private void DamageOrb(Vector3 _)
    {
        particleSettings = orbParticle.main;
        particleSettings.startLifetimeMultiplier *= 5f;
    }

    private void DestroyOrb()
    {
        rigidBody.useGravity = true;
        Instantiate(bigExplosionParticle, rigidBody.transform.position, Quaternion.identity);
        orbParticle.Stop();
    }
}