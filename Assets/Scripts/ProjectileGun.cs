using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileGun : Gun
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float projectileSpeed = 0.1f;

    public IObjectPool<GameObject> pool;

    private GameObject bulletObject;

    public override void Awake()
    {
        base.Awake();
        pool = new ObjectPool<GameObject>(createFunc: () => Instantiate(projectilePrefab, muzzleLocation.transform.position, Quaternion.identity),
actionOnGet: (obj) => obj.SetActive(true), actionOnRelease: (obj) => obj.SetActive(false),
actionOnDestroy: (obj) => Destroy(obj), collectionCheck: false, defaultCapacity: 5, maxSize: 20);
    }

    protected override void CreateProjectile(Vector3 targetPosition)
    {
        if (bulletObject)
        {
            Rigidbody rigidbody = bulletObject.GetComponentInChildren<Rigidbody>();
            rigidbody.angularVelocity = Vector3.zero;

            rigidbody.velocity = transform.forward * projectileSpeed;
        }
        else
        {
            bulletObject = pool.Get();
        }
    }
}