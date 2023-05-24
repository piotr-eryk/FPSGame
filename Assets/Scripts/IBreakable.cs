using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBreakable
{
    void OnBreak();
    void OnHit(DamageType damageType, Vector3 damagePosition);
}