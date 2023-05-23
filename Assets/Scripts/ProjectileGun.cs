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
    [SerializeField]
    private float shootingDelay = 3f;

    public IObjectPool<GameObject> pool;

    private GameObject bulletObject;

    public override void Awake()
    {
        base.Awake();
        pool = new ObjectPool<GameObject>(createFunc: () => Instantiate(projectilePrefab, muzzleLocation.transform.position, Quaternion.identity),
actionOnGet: (obj) => obj.SetActive(true), actionOnRelease: (obj) => obj.SetActive(false), collectionCheck: false, defaultCapacity: 5, maxSize: 20);
    }

    private void Start()
    {
        
    }

    protected override void CreateProjectile(RaycastHit targetPosition)//TODO: fix moving
    {
        bulletObject = pool.Get();
        Rigidbody rigidbody = bulletObject.GetComponent<Rigidbody>();
        bulletObject.transform.rotation= Quaternion.identity;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.velocity = Vector3.zero;
        rigidbody.velocity = cam.transform.forward * projectileSpeed;
        bulletObject.GetComponent<Projectile>().OnHit += BackProjectileToPool;

    }

    public void BackProjectileToPool(Projectile projectile)
    {
        projectile.gameObject.transform.position = muzzleLocation.transform.position;
        pool.Release(projectile.gameObject);
    }

    private void UnsubscribeEvent(Projectile projectile)
    {
        projectile.OnHit -= BackProjectileToPool;
    }
}