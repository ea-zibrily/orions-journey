using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSelect : MonoBehaviour
{
    public GameObject[] weaponPrefabs;
    int selectedWeapon;

    void Awake(){
        selectedWeapon = PlayerPrefs.GetInt("SelectedWeapon", 0);
        foreach(GameObject weapon in weaponPrefabs){
            weapon.SetActive(false);
        }

        weaponPrefabs[selectedWeapon].SetActive(true);
    }

    public void Next(){
        weaponPrefabs[selectedWeapon].SetActive(false);
        ++selectedWeapon;
        if(selectedWeapon == weaponPrefabs.Length){
            selectedWeapon = 0;
        }
        weaponPrefabs[selectedWeapon].SetActive(true);
        PlayerPrefs.SetInt("SelectedWeapon", selectedWeapon);
    }

    public void Back(){
        weaponPrefabs[selectedWeapon].SetActive(false);
        --selectedWeapon;
        if(selectedWeapon == -1){
            selectedWeapon = weaponPrefabs.Length - 1;
        }
        weaponPrefabs[selectedWeapon].SetActive(true);
        PlayerPrefs.SetInt("SelectedWeapon", selectedWeapon);
    }
}
