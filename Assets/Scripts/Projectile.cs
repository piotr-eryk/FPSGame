using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Action<Projectile> OnHit;

    [SerializeField]
    private DamageType damageType;

    public DamageType DamageType => damageType;

    private void OnDestroy()
    {
        Debug.Log("object destroyed");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        OnHit?.Invoke(this);
    }
}