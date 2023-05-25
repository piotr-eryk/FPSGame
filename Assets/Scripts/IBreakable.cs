using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBreakable
{
    void ObjectBreaked();
    void OnHit(DamageType damageType, Vector3 damagePosition);
}