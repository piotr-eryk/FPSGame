using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BreakableObject : MonoBehaviour, IBreakable
{
    public UnityEvent OnBreak;
    public Action<Vector3> OnDamage;

    [SerializeField]
    private DamageableObject damageableObject;
    [SerializeField]
    private DamageableObjectList damageableObjectList;

    private int currentHp;

    public DamageableObject DamageableObject => damageableObject;

    private void Awake()
    {
        currentHp = damageableObject.MaxHp;
    }

    public void ObjectBreaked()
    {
        OnBreak?.Invoke();
    }

    public void OnHit(DamageType damageType, Vector3 hitPoint)
    {
        var materialList = damageableObjectList.GetVulnerableMaterialsDamage(damageType);
        if (materialList.Item1.Contains(damageableObject.TypeOfMaterial) && currentHp>0)
        {
            currentHp -= damageableObjectList.GetVulnerableMaterialsDamage(damageType).Item2;

            OnDamage?.Invoke(hitPoint);

            if (currentHp <= 0)
            {
                ObjectBreaked();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Projectile>(out var projectile))
        {
            OnHit(projectile.DamageType, other.transform.position);
        }
    }
}
