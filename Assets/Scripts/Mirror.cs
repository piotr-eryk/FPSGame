using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField]
    private BreakableObject breakableObject;
    [SerializeField]
    private GameObject shatteredMirror;

    private void Awake()
    {
        breakableObject.ObjectBreaked += Shatter;
    }

    private void OnDestroy()
    {
        breakableObject.ObjectBreaked -= Shatter;
    }

    public void Shatter()
    {
        Debug.Log("Zbij");
        Instantiate(shatteredMirror, transform.position, Quaternion.identity);//TODO: pooling
        gameObject.SetActive(false);
    }
}
