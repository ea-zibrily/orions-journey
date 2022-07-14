using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class weaponSelect : MonoBehaviour
{
    [Header ("Weapon Prefabs")]
    public GameObject[] weaponPrefabs;
    int selectedWeapon;

    public weapons[] weapon;

    public Button priceButton;
    public TextMeshProUGUI coinsUI;
    public int coin;

    public GameObject yesOrNo;

    [Header ("Anim")]
    public Animator noCoinsAnim;
    public Animator purchaseSuccess;

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
            coin = coin + 2;
            PlayerPrefs.SetInt("totalCoin", coin);
        }
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
        UpdateButton();
    }

    public void UpdateButton(){
        coinsUI.text = PlayerPrefs.GetInt("totalCoin", 0).ToString();

        if(weapon[selectedWeapon].price == 0){
            priceButton.interactable = false;
            priceButton.GetComponentInChildren<TextMeshProUGUI>().text = "Default";
        } else {
            priceButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price : " + weapon[selectedWeapon].price;
            if(PlayerPrefs.GetInt("totalCoin", 0) < weapon[selectedWeapon].price){
                priceButton.interactable = true;
            } else {
                priceButton.interactable = true;
            }

            if(weapon[selectedWeapon].isUnlocked == true && weapon[selectedWeapon].price > 0){
                priceButton.interactable = false;
                priceButton.GetComponentInChildren<TextMeshProUGUI>().text = "Purchased";
            }
        }

        if(weapon[selectedWeapon].isUnlocked == true){
            PlayerPrefs.SetInt("SelectedWeapon", selectedWeapon);
        }
    }

    public void YesOrNo(){
        if(PlayerPrefs.GetInt("totalCoin", 0) < weapon[selectedWeapon].price){
            noCoinsAnim.SetTrigger("noCoins");
        } else {
            yesOrNo.gameObject.SetActive(true);
        }
    }

    public void Yes(){
        int coins = PlayerPrefs.GetInt("totalCoin", 0);
        int price = weapon[selectedWeapon].price;
        
        PlayerPrefs.SetInt("totalCoin", coins - price);
        PlayerPrefs.SetInt(weapon[selectedWeapon].name, 1);
        PlayerPrefs.SetInt("selectedWeapon", selectedWeapon);
        weapon[selectedWeapon].isUnlocked = true;
        UpdateButton();
        yesOrNo.gameObject.SetActive(false);
        purchaseSuccess.SetTrigger("purchaseSuccess");
    }

    public void No(){
        yesOrNo.gameObject.SetActive(false);
    }

    public void Back(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

}
