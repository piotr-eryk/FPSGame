using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileGun : Gun
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private float projectileSpeed;

    protected override void CreateProjectile(Vector3 targetPosition)
    {
        //TODO: change to pooling
        {
            GameObject bulletObject = Instantiate(projectilePrefab);

            if (bulletObject)
            {
                Rigidbody rigidbody = bulletObject.GetComponent<Rigidbody>();
                rigidbody.angularVelocity = Vector3.zero;

                bulletObject.transform.position = transform.position + transform.forward * 2f;
                bulletObject.transform.rotation = transform.rotation;
                bulletObject.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
                rigidbody.velocity = transform.forward * projectileSpeed;

                bulletObject.SetActive(true);
            }
        }
    }
}