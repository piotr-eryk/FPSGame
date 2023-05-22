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
    [SerializeField]
    private float fadeDelay = 0.05f;

    private Vector3 laserEndPosition;
    private LineRenderer line;

    protected override void CreateProjectile(Vector3 laserEnd)
    {
        if (line == null)
        {
            line = Instantiate(laser).GetComponent<LineRenderer>();
        }
        else
        {
            line.SetPositions(new Vector3[2] { muzzleLocation.transform.position, laserEnd });
        }

        laserEndPosition = laserEnd;
        StartCoroutine(TryFadeLaser(line)); //TODO: movement with fading laser is bugged
    }

    IEnumerator TryFadeLaser(LineRenderer line)
    {
        yield return new WaitForSeconds(fadeDelay);

        float alpha = 1;
        while (alpha > 0)
        {

            line.SetPositions(new Vector3[2] { muzzleLocation.transform.position, laserEndPosition });
            alpha -= Time.deltaTime / fadeDuration;
            line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, alpha);
            line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, alpha);
            yield return null;
        }
    }
}
