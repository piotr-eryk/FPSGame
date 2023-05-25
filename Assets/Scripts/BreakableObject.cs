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

    public void OnHit(DamageType damageType, Vector3 damagePlace)//TODO: parameter name
    {
        var materialList = damageableObjectList.GetVulnerableMaterials(damageType);
        if (materialList.Contains(damageableObject.TypeOfMaterial) && currentHp>0)
        {
            currentHp -= damageableObjectList.GetObjectDamage(damageType);

            OnDamage?.Invoke(damagePlace);

            if (currentHp <= 0)
            {
                ObjectBreaked();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Projectile>())//TODO: merge these two
        {
            var damageType = other.gameObject.GetComponent<Projectile>().DamageType;
            OnHit(damageType, other.transform.position);
        }
    }
}
