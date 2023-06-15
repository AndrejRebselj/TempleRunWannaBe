using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSelectionController : MonoBehaviour
{
    MyButton stick;
    MyButton sai;
    MyButton sword;

    MyButton red;
    MyButton green;
    MyButton purple;

    List<MyButton> weapons;
    List<MyButton> skins;

    int swordPrice = 10000;
    int saiPrice = 100000;

    int greenPrice = 5000;
    int purplePrice = 5000;


    void Awake()
    {
        weapons = new List<MyButton>();
        skins = new List<MyButton>();
        //init weapons
        stick = new MyButton("ShopItemStick");
        sai = new MyButton("ShopItemSai");
        sword = new MyButton("ShopItemSword");

        weapons.Add(stick);
        weapons.Add(sword);
        weapons.Add(sai);

        //init skins
        red = new MyButton("ShopSkinBlack");
        green = new MyButton("ShopSkinBrown");
        purple = new MyButton("ShopSkinGreen");

        skins.Add(red);
        skins.Add(green);
        skins.Add(purple);

        SetupButtons();

        //onClick weapons
        stick.OnClick(() => {
            if (stick.GiveMeButtonImageObject().color==Color.yellow)
            {
                SetupSoThatOnlyOneWeaponIsSelected(stick);
                StoreSaver.pickedWeapon = stick.Name;
            }
            else if(stick.GiveMeButtonImageObject().color == Color.red)
            {
                stick.GiveMeButtonImageObject().color = Color.yellow;
                StoreSaver.gottenWeapons.Add(1);
            }
        });
        sai.OnClick(() => {
            if (sai.GiveMeButtonImageObject().color == Color.yellow)
            {
                SetupSoThatOnlyOneWeaponIsSelected(sai);
                StoreSaver.pickedWeapon = sai.Name;
            }
            else if (sai.GiveMeButtonImageObject().color == Color.red)
            {
                if (saiPrice<=StoreSaver.currency)
                {
                    StoreSaver.currency -= saiPrice;
                    sai.GiveMeButtonImageObject().color = Color.yellow;
                    StoreSaver.gottenWeapons.Add(1);
                }
            }
        });
        sword.OnClick(() => {
            if (sword.GiveMeButtonImageObject().color == Color.yellow)
            {
                SetupSoThatOnlyOneWeaponIsSelected(sword);
                StoreSaver.pickedWeapon = sword.Name;
            }
            else if (sword.GiveMeButtonImageObject().color == Color.red)
            {
                if (swordPrice<=StoreSaver.currency)
                {
                    StoreSaver.currency-=swordPrice;
                    sword.GiveMeButtonImageObject().color = Color.yellow;
                    StoreSaver.gottenWeapons.Add(1);
                }
            }
        });

        //onClick skins
        red.OnClick(() => {
            if (red.GiveMeButtonImageObject().color == Color.yellow)
            {
                SetupSoThatOnlyOneSkinIsSelected(red);
                StoreSaver.pickedSkin = red.Name;
            }
            else if (red.GiveMeButtonImageObject().color == Color.red)
            {
                red.GiveMeButtonImageObject().color = Color.yellow;
                StoreSaver.gottenSkins.Add(1);
            }
        });
        green.OnClick(() => {
            if (green.GiveMeButtonImageObject().color == Color.yellow)
            {
                SetupSoThatOnlyOneSkinIsSelected(green);
                StoreSaver.pickedSkin = green.Name;
            }
            else if (green.GiveMeButtonImageObject().color == Color.red)
            {
                if (greenPrice<=StoreSaver.currency)
                {
                    StoreSaver.currency -= greenPrice;
                    green.GiveMeButtonImageObject().color = Color.yellow;
                    StoreSaver.gottenSkins.Add(1);
                }
            }
        });
        purple.OnClick(() => {
            if (purple.GiveMeButtonImageObject().color == Color.yellow)
            {
                SetupSoThatOnlyOneSkinIsSelected(purple);
                StoreSaver.pickedSkin = purple.Name;
            }
            else if (purple.GiveMeButtonImageObject().color == Color.red)
            {
                if (purplePrice<=StoreSaver.currency)
                {
                    StoreSaver.currency-= purplePrice;
                    purple.GiveMeButtonImageObject().color = Color.yellow;
                    StoreSaver.gottenSkins.Add(1);
                }
            }
        });
    }

    private void SetupSoThatOnlyOneWeaponIsSelected(MyButton weapon)
    {
        weapons.ForEach(x =>
        {
            if (x.GiveMeButtonImageObject().color == Color.green)
            {
                x.GiveMeButtonImageObject().color = Color.yellow;
            }
        });
        weapon.GiveMeButtonImageObject().color = Color.green;
    }
    private void SetupSoThatOnlyOneSkinIsSelected(MyButton skin)
    {
        skins.ForEach(x =>
        {
            if (x.GiveMeButtonImageObject().color == Color.green)
            {
                x.GiveMeButtonImageObject().color = Color.yellow;
            }
        });
        skin.GiveMeButtonImageObject().color = Color.green;
    }

    private void SetupButtons()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (PlayerPrefs.GetInt($"{PlayerPrefsStrings.ShopWeapon}{i}")==1)
            {
                weapons[i].GiveMeButtonImageObject().color = Color.yellow;
            }
            else
            {
                weapons[i].GiveMeButtonImageObject().color = Color.red;
            }
            if (PlayerPrefs.GetString(PlayerPrefsStrings.PickedWeapon) == weapons[i].Name)
            {
                weapons[i].GiveMeButtonImageObject().color = Color.green;
            }
        }
        for (int i = 0; i < skins.Count; i++)
        {
            if (PlayerPrefs.GetInt($"{PlayerPrefsStrings.ShopSkin}{i}") == 1)
            {
                skins[i].GiveMeButtonImageObject().color = Color.yellow;
            }
            else
            {
                skins[i].GiveMeButtonImageObject().color = Color.red;
            }
            if (PlayerPrefs.GetString(PlayerPrefsStrings.PickedSkin) == skins[i].Name)
            {
                skins[i].GiveMeButtonImageObject().color = Color.green;
            }
        }
    }
    private void OnApplicationQuit()
    {
        Debug.Log("Triggeran sam");
    }
}
