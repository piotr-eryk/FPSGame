using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOrb : MonoBehaviour
{
    [SerializeField]
    private Material material;
    [SerializeField]
    private BreakableObject breakableObject;

    private void Awake()
    {
        breakableObject.ObjectDamaged += ChangeColor;
    }

    private void Update()
    {
 
    }

    private void OnDestroy()
    {
        breakableObject.ObjectDamaged -= ChangeColor;//TODO: this color will change only once
    }

    private void ChangeColor()
    {

    }
}
