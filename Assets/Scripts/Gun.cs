using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Transform cam;

    [SerializeField]
    private float range = 50f;
    [SerializeField]
    private DamageType damageType;
    [SerializeField]
    private DamageableObjectList damageableObjectList;
    [SerializeField]
    protected GameObject muzzleLocation;
    [SerializeField]
    protected GameObject projectilePrefab;
    
    protected RaycastHit hitTarget;

    private void Awake()
    {
        cam = Camera.main.transform;
    }

    public virtual void Shoot()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hitTarget, range))
        {
            Debug.Log(hitTarget.collider.name);
        }
    }
}
