using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Shop/Weapon")]
public class WeaponShopItem : ScriptableObject
{
    public string weapon_name;
    public GameObject weaponObject;
}
