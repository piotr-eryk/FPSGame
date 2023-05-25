using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyingEffects : MonoBehaviour
{
    public UnityEvent OnDestroy;

    private void ObjectDestroyed()
    {
        OnDestroy?.Invoke();
    }
}