using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupWeaponAndCharacterSkin : MonoBehaviour
{
    [SerializeField]
    GameObject weaponHolderObject;
    [SerializeField]
    List<Material> materials;
    [SerializeField]
    List<GameObject> weaponSkins;
    [SerializeField]
    SkinnedMeshRenderer playerMeshRenderer;

    void Awake()
    {
        weaponSkins.ForEach(x => {
            if (x.gameObject.name==PlayerPrefsWeaponNameTranslator(StoreSaver.pickedWeapon))
            {
                GameObject gm = Instantiate(x, weaponHolderObject.transform);
            }
        });
        materials.ForEach(x => {
            if (x.name == PlayerPrefsSkinNameTranslator(StoreSaver.pickedSkin))
            {
                playerMeshRenderer.material = x;
            }
        });
    }

    string PlayerPrefsWeaponNameTranslator(string SS) 
    {
        switch (SS)
        {
            case "ShopItemStick":
                return weaponSkins[0].name;
            case "ShopItemSword":
                return weaponSkins[1].name;
            case "ShopItemSai":
                return weaponSkins[2].name;
            default:
                return weaponSkins[0].name;
        }
    }
    string PlayerPrefsSkinNameTranslator(string SS)
    {
        switch (SS)
        {
            case "ShopSkinBlack":
                return materials[0].name;
            case "ShopSkinBrown":
                return materials[1].name;
            case "ShopSkinGreen":
                return materials[2].name;
            default:
                return materials[0].name;
        }
    }

}
