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
    private GameObject projectileParticleContainer;

    public IObjectPool<GameObject> projectilePool;
    public IObjectPool<GameObject> particlePool;

    private GameObject bulletObject;

    public override void Awake()
    {
        base.Awake();
        projectilePool = new ObjectPool<GameObject>(createFunc: () => Instantiate(projectilePrefab, muzzleLocation.transform.position, Quaternion.identity),
actionOnGet: (obj) => obj.SetActive(true), actionOnRelease: (obj) => obj.SetActive(false), collectionCheck: false, defaultCapacity: 5, maxSize: 20);
        if (projectileParticleContainer!= null )
        {
            particlePool = new ObjectPool<GameObject>(createFunc: () => Instantiate(projectileParticleContainer, muzzleLocation.transform.position, Quaternion.identity),
actionOnGet: (obj) => obj.SetActive(true), actionOnRelease: (obj) => obj.SetActive(false), collectionCheck: false, defaultCapacity: 5, maxSize: 20);
        }
    }

    protected override void CreateProjectile(RaycastHit targetPosition)//TODO: fix moving
    {
        bulletObject = projectilePool.Get();
        Rigidbody rigidbody = bulletObject.GetComponent<Rigidbody>();
        bulletObject.transform.position = muzzleLocation.transform.position;
        bulletObject.transform.rotation = Quaternion.identity;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.velocity = Vector3.zero;
        rigidbody.velocity = cam.transform.forward * projectileSpeed;
        bulletObject.GetComponent<Projectile>().OnHit += BackToPool;
        CreateParticle();
    }

    private void CreateParticle()
    {
        if (projectileParticleContainer != null)
        {
            var particle = particlePool.Get();
            particle.transform.rotation = transform.rotation;
            particle.transform.position = muzzleLocation.transform.position;
            particle.GetComponent<BackToPoolController>().OnParticleStop += BackToPool;
        }   
    }

    public void BackToPool(Projectile objectToReturn)
    {
        objectToReturn.transform.position = muzzleLocation.transform.position;
        projectilePool.Release(objectToReturn.gameObject);
    }

    public void BackToPool(GameObject objectToReturn)
    {
        objectToReturn.transform.position = muzzleLocation.transform.position;
        particlePool.Release(objectToReturn);
    }
}