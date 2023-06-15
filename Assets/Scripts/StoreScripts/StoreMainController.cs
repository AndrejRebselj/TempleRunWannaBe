using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreMainController : MonoBehaviour
{
    [SerializeField]
    GameObject weaponPalen;
    [SerializeField]
    GameObject skinPalen;
    void Start()
    {
        //init buttons
        MyButton weapons = new MyButton("Weapon");
        MyButton backButton = new MyButton("BackButton");
        MyButton skins = new MyButton("CharacterSkins");
        MyLabel currency = new MyLabel("CurrencyText");
        //labels
        weapons.SetText("Weapons");
        backButton.SetText("Back");
        currency.SetText($"Currency: {StoreSaver.currency}");
        skins.SetText("Skins");
        //setup what you see
        skinPalen.SetActive(true);
        weaponPalen.SetActive(false);
        //OnClick
        weapons.OnClick(() => {
            skinPalen.SetActive(false);
            weaponPalen.SetActive(true);
            weapons.SetImgOpacity(1f);
            skins.SetImgOpacity(0f);
        });
        backButton.OnClick(() => {
            StoreSaver.SaveData();
            NavigationFramework.RemoveViewNode();
        });
        skins.OnClick(() => {
            skinPalen.SetActive(true);
            weaponPalen.SetActive(false);
            weapons.SetImgOpacity(0f);
            skins.SetImgOpacity(1f);
        });
    }
}
