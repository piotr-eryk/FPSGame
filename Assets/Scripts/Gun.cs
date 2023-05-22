using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    protected Transform cam;

    [SerializeField]
    protected float range = 50f;
    [SerializeField]
    protected DamageType damageType;
    [SerializeField]
    protected DamageableObjectList damageableObjectList;
    [SerializeField]
    protected GameObject muzzleLocation;

    protected RaycastHit hitTarget;

    public virtual void Awake()
    {
        cam = Camera.main.transform;
    }

    public virtual void Shoot()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hitTarget, range))
        {
            CreateProjectile(hitTarget.point);
        }
    }

    protected abstract void CreateProjectile(Vector3 targetPoint);
}
