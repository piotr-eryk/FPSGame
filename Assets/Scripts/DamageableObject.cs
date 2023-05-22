using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Breakable Object", menuName = "ScriptableObjects/NewBreakableObject")]
public class DamageableObject : ScriptableObject
{
    [SerializeField]
    private int maxHp;
    [SerializeField]
    private MaterialType materialType;

    public int MaxHp => maxHp;
    public MaterialType TypeOfMaterial => materialType;
}
