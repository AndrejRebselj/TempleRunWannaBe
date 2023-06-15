using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveableScript
{
    public int currency;
    public List<string> unlockedWeapons;
    public List<string> unlockedSkins;
    public string pickedSkin;
    public string pickedWeapon;

    public SaveableScript() 
    {
        ReadSavedJson();
    }

    private void ReadSavedJson()
    {
        if (File.Exists(Application.persistentDataPath + "/saves.json"))
        {
            string json=File.ReadAllText(Application.persistentDataPath + "/saves.json");
            currency = JsonUtility.FromJson<SaveableScript>(json).currency;
            unlockedWeapons = JsonUtility.FromJson<SaveableScript>(json).unlockedWeapons;
            unlockedSkins = JsonUtility.FromJson<SaveableScript>(json).unlockedSkins;
            pickedSkin = JsonUtility.FromJson<SaveableScript>(json).pickedSkin;
            pickedWeapon = JsonUtility.FromJson<SaveableScript>(json).pickedWeapon;
        }
        else
        {
            currency = 0;
            unlockedWeapons = new List<string>();
            unlockedSkins = new List<string>();
            pickedSkin = "Red";
            pickedWeapon = "Stick";
        }
    }

    public void SaveSaveableScript() 
    {
        string json= JsonUtility.ToJson(this);
        File.WriteAllText(Application.persistentDataPath + "/saves.json", json);
    }

}
