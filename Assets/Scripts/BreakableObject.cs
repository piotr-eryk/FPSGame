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
    [SerializeField]
    private GameObject damageTrail;

    private int currentHp;

    public DamageableObject DamageableObject => damageableObject;

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
        Debug.Log("TRAFIONY");
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigerr");
        if (other.gameObject.GetComponent<Projectile>())//TODO: merge these two
        {
            var damageType = other.gameObject.GetComponent<Projectile>().DamageType;
            OnHit(damageType);
        }
    }
}
