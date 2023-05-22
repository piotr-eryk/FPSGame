using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class Laser : Gun
{
    [SerializeField]
    private GameObject laser;
    [SerializeField]
    private float fadeDuration = 0.1f;

    LineRenderer line;

    protected override void CreateProjectile(Vector3 laserEnd)
    {
        line = Instantiate(laser).GetComponent<LineRenderer>();//TODO: change to pooling
        line.SetPositions(new Vector3[2] { muzzleLocation.transform.position, laserEnd });
        StartCoroutine(FadeLaser(line));
    }

    IEnumerator FadeLaser(LineRenderer line)
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeDuration;
            line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, alpha);
            line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, alpha);
            yield return null;
        }
    }
}
