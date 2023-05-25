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

    private void OnCollisionEnter(Collision collision)
    {
        OnHit?.Invoke(this);
    }
}