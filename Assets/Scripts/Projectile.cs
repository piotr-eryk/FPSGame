using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Action OnHit;

    private void OnCollisionEnter(Collision _)
    {
        OnHit?.Invoke();
    }
}
