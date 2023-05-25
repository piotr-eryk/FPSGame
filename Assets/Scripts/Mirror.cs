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
    private GameObject bulletHoleImageContainer;

    private void Awake()
    {
        breakableObject.OnBreak += Shatter;
        breakableObject.OnDamage += CreateHole;
    }

    private void OnDestroy()
    {
        breakableObject.OnBreak -= Shatter;
        breakableObject.OnDamage -= CreateHole;
    }

    public void Shatter()
    {
        Instantiate(shatteredMirror, transform.position, Quaternion.identity);//TODO: pooling
        gameObject.SetActive(false);
    }

    public void CreateHole(Vector3 holePoint)
    {
        //Instantiate(bulletHoleImageContainer, holePoint, Quaternion.identity);
    }
}
