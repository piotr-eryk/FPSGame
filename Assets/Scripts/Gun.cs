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
    [SerializeField]
    public GameObject recoilPart;

    protected RaycastHit hitTarget;

    public virtual void Awake()
    {
        cam = Camera.main.transform;
    }

    public virtual void Shoot()
    {
        if (gameObject.activeSelf && Physics.Raycast(cam.position, cam.forward, out hitTarget, range))
        {
            StartCoroutine(StartRecoil());
            CreateProjectile(hitTarget);
        }
    }

    protected abstract void CreateProjectile(RaycastHit targetPoint);

    private IEnumerator StartRecoil()
    {
        recoilPart.GetComponent<Animator>().Play("LaserGun");
        yield return new WaitForSeconds(0.20f);
        recoilPart.GetComponent<Animator>().Play("New State");
    }
}
