using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> imagesList;
    [SerializeField]
    private List<GameObject> weaponList;

    private int currentWeaponIndex = 0;


    public void SwitchWeapon(int weaponIndex)
    {
        weaponList[currentWeaponIndex].SetActive(false);//TODO: that doesnt look good
        imagesList[currentWeaponIndex].SetActive(false);
        currentWeaponIndex = weaponIndex;
        weaponList[currentWeaponIndex].SetActive(true);
        imagesList[currentWeaponIndex].SetActive(true);
    }
}