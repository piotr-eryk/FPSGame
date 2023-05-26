using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DestructibleWood : MonoBehaviour
{
    [SerializeField]
    private BreakableObject breakableObject;
    [SerializeField]
    private GameObject fireParticle;
    [SerializeField]
    private ParticleSystem bigFireParticle;

    public IObjectPool<GameObject> fireParticlePool;

    private GameObject fireParticleContainer;

    private void Awake()
    {
        breakableObject.OnDamage += CreateFire;
        breakableObject.OnBreak.AddListener(BurnObject);
        fireParticlePool = new ObjectPool<GameObject>(createFunc: () => Instantiate(fireParticle),
actionOnGet: (obj) => obj.SetActive(true), actionOnRelease: (obj) => obj.SetActive(false), collectionCheck: false, defaultCapacity: 5, maxSize: 20);
    }

    private void OnDestroy()
    {
        breakableObject.OnDamage -= CreateFire;
        breakableObject.OnBreak.RemoveListener(BurnObject);
    }

    private void CreateFire(Vector3 damagePlace)
    {
        fireParticleContainer = fireParticlePool.Get();
        fireParticleContainer.transform.position = damagePlace;
    }

    private void BurnObject()
    {
        bigFireParticle.gameObject.SetActive(true);
        bigFireParticle.Play();
    }
}
