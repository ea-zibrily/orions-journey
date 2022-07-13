using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class weaponSelect : MonoBehaviour
{
    public GameObject[] weaponPrefabs;
    int selectedWeapon;

    public weapons[] weapon;

    public Button priceButton;
    public TextMeshProUGUI coinsUI;
    public int coin;

    void Awake(){
        selectedWeapon = PlayerPrefs.GetInt("SelectedWeapon", 0);
        foreach(GameObject weapon in weaponPrefabs){
            weapon.SetActive(false);
        }
        weaponPrefabs[selectedWeapon].SetActive(true);

        foreach(weapons w in weapon){
            if(w.price == 0){
                w.isUnlocked = true;
            } else{
                if(PlayerPrefs.GetInt(w.name, 0) == 0){
                    w.isUnlocked = false;
                } else{
                    w.isUnlocked = true;
                }
            }
        }
        UpdateButton();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            PlayerPrefs.DeleteAll();
            Debug.Log("deleted");
        }
        if(Input.GetKeyDown(KeyCode.R)){
            coin = 2;
            PlayerPrefs.SetInt("totalCoin", coin);
        }
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

    public void ChangeWeapons(){
        GameObject tempBtn = EventSystem.current.currentSelectedGameObject;
        int tempBtnIndex = tempBtn.transform.GetSiblingIndex();
        WeaponChanged(tempBtnIndex);
    }

    void WeaponChanged(int weaponIndex){
        weaponPrefabs[selectedWeapon].SetActive(false);
        selectedWeapon = weaponIndex;
        weaponPrefabs[selectedWeapon].SetActive(true);
        if(weapon[selectedWeapon].isUnlocked == true){
            PlayerPrefs.SetInt("SelectedWeapon", selectedWeapon);
        }
        UpdateButton();
    }

    public void UpdateButton(){
        coinsUI.text = PlayerPrefs.GetInt("totalCoin", 0).ToString();

        if(weapon[selectedWeapon].price == 0){
            priceButton.gameObject.SetActive(false);
        } else {
            priceButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price : " + weapon[selectedWeapon].price;
            if(PlayerPrefs.GetInt("totalCoin", 0) < weapon[selectedWeapon].price){
                priceButton.gameObject.SetActive(true);
                priceButton.interactable = false;
            } else {
                priceButton.gameObject.SetActive(true);
                priceButton.interactable = true;
            }
        }

        if(priceButton.interactable == false && weapon[selectedWeapon].isUnlocked == true){
            priceButton.GetComponentInChildren<TextMeshProUGUI>().text = "Purchased";
        }
    }

    public void Unlock(){
        int coins = PlayerPrefs.GetInt("totalCoin", 0);
        int price = weapon[selectedWeapon].price;
        
        PlayerPrefs.SetInt("totalCoin", coins - price);
        PlayerPrefs.SetInt(weapon[selectedWeapon].name, 1);
        PlayerPrefs.SetInt("selectedWeapon", selectedWeapon);
        weapon[selectedWeapon].isUnlocked = true;
        UpdateButton();
    }
}
