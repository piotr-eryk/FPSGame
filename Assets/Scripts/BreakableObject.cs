using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BreakableObject : MonoBehaviour, IBreakable
{
    public Action ObjectBreaked;
    public Action ObjectDamaged;

    [SerializeField]
    private DamageableObject damageableObject;
    [SerializeField]
    private DamageableObjectList damageableObjectList;

    private int currentHp;

    private void Awake()
    {
        currentHp = damageableObject.MaxHp;
    }

    public void OnBreak()
    {
        ObjectBreaked?.Invoke();
    }

    public void OnHit(DamageType damageType)
    {

        var materialList = damageableObjectList.GetVulnerableMaterials(damageType);
        if (materialList.Contains(damageableObject.TypeOfMaterial) && currentHp>0)
        {
            currentHp -= damageableObjectList.GetObjectDamage(damageType);

            ObjectDamaged?.Invoke();

            if (currentHp <= 0)
            {
                OnBreak();
            }
        }
    }
}
