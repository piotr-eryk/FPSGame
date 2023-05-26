using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToPoolController : MonoBehaviour
{
    public Action <GameObject> OnParticleStop;

    [SerializeField] 
    private ParticleSystem particle;

    private void Update()
    {
        if (particle.isStopped)
        {
            ParticleStopped();
        }
    }

    public void ParticleStopped()
    {
        OnParticleStop?.Invoke(gameObject);
    }
}
