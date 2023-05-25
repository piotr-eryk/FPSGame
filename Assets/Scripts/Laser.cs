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

    private RaycastHit laserEndPosition;
    private LineRenderer line;

    protected override void CreateProjectile(RaycastHit laserEnd)
    {
        if (line == null)
        {
            line = Instantiate(laser).GetComponent<LineRenderer>();
        }
        else
        {
            line.SetPositions(new Vector3[2] { muzzleLocation.transform.position, laserEnd.point });
        }

        if (laserEnd.collider.gameObject.TryGetComponent<BreakableObject>(out var breakable) && 
            damageableObjectList.GetVulnerableMaterialsDamage(damageType).Item1.Contains(breakable.DamageableObject.TypeOfMaterial))
        {
            breakable.OnHit(damageType, laserEnd.point);
        }

        laserEndPosition = laserEnd;
        StartCoroutine(FadeLaser(line)); //TODO: movement with fading laser is bugged
    }



    IEnumerator FadeLaser(LineRenderer line)
    {
        float alpha = 1;
        while (alpha > 0)
        {
            line.SetPositions(new Vector3[2] { muzzleLocation.transform.position, laserEndPosition.point });
            alpha -= Time.deltaTime / fadeDuration;
            line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, alpha);
            line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, alpha);
            yield return null;
        }
    }
}
