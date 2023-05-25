using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damageable Object List", menuName = "ScriptableObjects/NewDamageableObjectList")]
public class DamageableObjectList : ScriptableObject
{
    [Serializable]
    private class MaterialVulnerability
    {
        public List <MaterialType> materialTypes;
        public DamageType damageType;
        public int damage;
    }

    [SerializeField]
    private List<DamageableObject> listOfObjects;
    [SerializeField]
    private List<MaterialVulnerability> materialVulnerabilities;

    public (List<MaterialType>, int) GetVulnerableMaterialsDamage(DamageType damageType)
    {
        foreach (var vulnerability in materialVulnerabilities)
        {
            if (vulnerability.damageType == damageType)
            {
                return (vulnerability.materialTypes, vulnerability.damage);
            }
        }
        return (null, 0);
    }
}
