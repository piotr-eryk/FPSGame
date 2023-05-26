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

    public void SwitchWeapon(int newWeaponIndex)
    {
        weaponList[currentWeaponIndex].SetActive(false);
        imagesList[currentWeaponIndex].SetActive(false);
        currentWeaponIndex = newWeaponIndex;
        weaponList[currentWeaponIndex].SetActive(true);
        imagesList[currentWeaponIndex].SetActive(true);
    }
}