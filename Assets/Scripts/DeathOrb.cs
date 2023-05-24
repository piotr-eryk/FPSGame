using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOrb : MonoBehaviour
{
    [SerializeField]
    private Renderer materialToChange;
    [SerializeField]
    private BreakableObject breakableObject;
    [SerializeField]
    private Color endColor;
    [SerializeField]
    private Rigidbody moveablePart;
    [SerializeField]
    private GameObject rewardForDestroy;
    [SerializeField]
    private float rewardFlyHeigh = 7f;
    [SerializeField]
    private float orbRotatingSpeed = 100f;
    [SerializeField]
    private GameObject explosionParticle;

    private Color startingColor;
    private GameObject reward;

    private void Awake()
    {
        breakableObject.ObjectDamaged += ChangeColor;
        breakableObject.ObjectBreaked += OpenOrb;
        startingColor = materialToChange.materials[1].color;//TODO: magic number
    }

    void Update()
    {
        if (reward)
        {
            reward.transform.Rotate(orbRotatingSpeed * Time.deltaTime, orbRotatingSpeed * Time.deltaTime, orbRotatingSpeed * Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        breakableObject.ObjectDamaged -= ChangeColor;
        breakableObject.ObjectBreaked -= OpenOrb;
    }

    private void ChangeColor(Vector3 _)
    {
        var lerpedColor = Color.Lerp(startingColor, endColor, .5f);
        materialToChange.materials[1].color = lerpedColor;
        startingColor = materialToChange.materials[1].color;
    }

    private void OpenOrb()
    {
        var particle = Instantiate(explosionParticle, moveablePart.transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
        moveablePart.gameObject.SetActive(false);
        GiveReward();
    }

    private void GiveReward()
    {
        reward = Instantiate(rewardForDestroy, transform.position, Quaternion.identity);
        if (reward != null)
        {
            StartCoroutine(FlyReward());
        }
    }

    private IEnumerator FlyReward()
    {
        while (reward.transform.position.y <= rewardFlyHeigh)
        {
            reward.transform.position = new Vector3(reward.transform.position.x, reward.transform.position.y, reward.transform.position.z) + Time.deltaTime * Vector3.up;
            yield return null;
        }
    }
}
