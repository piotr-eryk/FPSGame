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
    [SerializeField]
    private Rigidbody moveablePart;
    [SerializeField]
    private float moveablePartVelocity = 5f;

    private Color startingColor;

    private void Awake()
    {
        breakableObject.ObjectDamaged += ChangeColor;
        breakableObject.ObjectBreaked += OpenOrb;
        startingColor = materialToChange.materials[1].color;//TODO: magic number
    }

    private void OnDestroy()
    {
        breakableObject.ObjectDamaged -= ChangeColor;
        breakableObject.ObjectBreaked -= OpenOrb;
    }

    private void ChangeColor()
    {
        var lerpedColor = Color.Lerp(startingColor, endColor, .5f);
        materialToChange.materials[1].color = lerpedColor;
        startingColor = materialToChange.materials[1].color;
    }

    private void OpenOrb()
    {
        Debug.Log("£OTWIEROJ PANOCKU");
        moveablePart.useGravity = true;
        moveablePart.velocity = transform.up * moveablePartVelocity;
        StartCoroutine(HideUpperOrbPart());
    }

    IEnumerator HideUpperOrbPart()
    {
        yield return new WaitForSeconds(1f);
        moveablePart.gameObject.SetActive(false);
    }
}
