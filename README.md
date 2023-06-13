# FPS Game
It is game demo where you can destroy various objects using guns with different types of damage.
## Technologies
* C#
* Unity 2021.3.15f1
## Code example
An example code would be a function called every time the player damage objects with one of his guns.

### Creating Projectile

 ```
    protected abstract void CreateProjectile(RaycastHit targetPoint);
 
    public virtual void Shoot()
    {
        if (gameObject.activeSelf && Physics.Raycast(cam.position, cam.forward, out hitTarget, range))
        {
            StartCoroutine(StartRecoil());
            CreateProjectile(hitTarget);
        }
    }

 ```   
### Overriding Create Projectile abstract method.

```
    protected override void CreateProjectile(RaycastHit laserEnd)
    {
        line.SetPositions(new Vector3[2] { muzzleLocation.transform.position, laserEnd.point });

        if (laserEnd.collider.gameObject.TryGetComponent<BreakableObject>(out var breakable) &&
            damageableObjectList.GetVulnerableMaterialsDamage(damageType).Item1.Contains(breakable.DamageableObject.TypeOfMaterial))
        {
            breakable.OnHit(damageType, laserEnd.point);
        }

        laserEndPosition = laserEnd;
        StartCoroutine(FadeLaser(line));
    }
 ```   
### OnHit method

```
    public void OnHit(DamageType damageType, Vector3 hitPoint)
    {
        var materialList = damageableObjectList.GetVulnerableMaterialsDamage(damageType);
        if (materialList.Item1.Contains(damageableObject.TypeOfMaterial) && currentHp>0)
        {
            currentHp -= damageableObjectList.GetVulnerableMaterialsDamage(damageType).Item2;

            OnDamage?.Invoke(hitPoint);

            if (currentHp <= 0)
            {
                ObjectBreaked();
            }
        }
    }
 ```   
### Subscribing OnDamage and OnBreak events
```
    private void Awake()
    {
        breakableObject.OnDamage += CreateFire;
        breakableObject.OnBreak.AddListener(BurnObject);
        fireParticlePool = new ObjectPool<GameObject>(createFunc: () => Instantiate(fireParticle),
actionOnGet: (obj) => obj.SetActive(true), actionOnRelease: (obj) => obj.SetActive(false), collectionCheck: false, defaultCapacity: 5, maxSize: 20);
    }
 ```   
### And subsribed method to OnBreak and OnDamage
```
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
 ```   
