using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField]
    private BreakableObject breakableObject;
    [SerializeField]
    private GameObject shatteredMirror;
    [SerializeField]
    private GameObject unbrokenMirror;

    private void Awake()
    {
        breakableObject.OnBreak.AddListener(BrokeMirror);
    }

    private void OnDestroy()
    {
        breakableObject.OnBreak.RemoveListener(BrokeMirror);
    }

    public void BrokeMirror()
    {
        unbrokenMirror.SetActive(false);
        shatteredMirror.SetActive(true);
    }
}
