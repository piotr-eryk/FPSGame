using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOrb : MonoBehaviour
{
    [SerializeField]
    private Renderer materialToChange;
    [SerializeField]
    private BreakableObject breakableObject;
    [SerializeField]
    private Color endColor;

    private Color startingColor;

    private void Awake()
    {
        breakableObject.ObjectDamaged += ChangeColor;
        startingColor = materialToChange.sharedMaterials[1].color;
    }

    private void Update()
    {

    }

    private void OnDestroy()
    {
        breakableObject.ObjectDamaged -= ChangeColor;
    }

    private void ChangeColor()
    {
        var lerpedColor = Color.Lerp(startingColor, endColor, .3f);
        GetComponentInChildren<Renderer>().sharedMaterials[1].color = lerpedColor;
        startingColor = gameObject.GetComponentInChildren<Renderer>().sharedMaterials[1].color;
    }
}
