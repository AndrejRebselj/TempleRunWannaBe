using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Scenes
{
    GameScene,
    MainMenu,
    SettingScene,
    StoreScene

}
public struct SceneNames
{
    public static string MainMenu = "MainMenu";
    public static string GameScene = "GameScene";
    public static string SettingScene = "SettingsScene";
    public static string StoreScene = "StoreScene";
}
public class MainController : MonoBehaviour
{
    void Start()
    {
        StoreSaver.LoadData();
        NavigationFramework.SetRootViewNode(new MainMenuController());
    }
}

public class MainMenuController : SceneNode
{
    public MainMenuController() : base(SceneNames.MainMenu)
    {
    }

    public override void SceneDidLoad() 
    {
        base.SceneDidLoad();
        //PlayButton
        MyButton playButton = new MyButton("PlayButton");
        playButton.SetText("Start");
        playButton.OnClick(() => {
            PushSceneNode(SceneProvider.GetSceneNode(Scenes.GameScene));
        });
        //Settings button
        MyButton settingsBUtton = new MyButton("SettingsButton");
        settingsBUtton.SetText("Options");
        settingsBUtton.OnClick(() =>
        {
            PushSceneNode(SceneProvider.GetSceneNode(Scenes.SettingScene));
        });
        //Store button
        MyButton storeButton = new MyButton("StoreButton");
        storeButton.SetText("Store");
        storeButton.OnClick(() =>
        {
            PushSceneNode(SceneProvider.GetSceneNode(Scenes.StoreScene));
        });
        //Quit button
        MyButton quitButton = new MyButton("QuitButton");
        quitButton.SetText("Quit");
        quitButton.OnClick(() =>
        {
            Application.Quit();
        });
        //Ad button
        MyButton adButton = new MyButton("AdButton");
        adButton.SetText("Get 1000 currency");

    }
}

public class GameScene : SceneNode 
{
    public GameScene() : base(SceneNames.GameScene) { }
}

public class MainMenu : SceneNode
{
    public MainMenu() : base(SceneNames.MainMenu) { }
}
public class SettingScene : SceneNode
{
    public SettingScene() : base(SceneNames.SettingScene) { }
}
public class StoreScene : SceneNode
{
    public StoreScene() : base(SceneNames.StoreScene) { }
}

public struct SceneProvider 
{
    public static SceneNode GetSceneNode(Scenes scene) 
    {
        switch (scene)
        {
            case Scenes.GameScene:
                return new GameScene();
            case Scenes.MainMenu:
                return new MainMenu();
            case Scenes.StoreScene:
                return new StoreScene();
            case Scenes.SettingScene:
                return new SettingScene();
            default:
                throw new System.NotImplementedException();
        }
    }
}

public static class StoreSaver
{
    public static int currency;
    public static List<int> gottenWeapons = new List<int>();
    public static List<int> gottenSkins = new List<int>();
    public static string pickedWeapon;
    public static string pickedSkin;

    public static void SaveData() 
    {
        PlayerPrefs.SetInt(PlayerPrefsStrings.Currency,currency);
        PlayerPrefs.SetString(PlayerPrefsStrings.PickedWeapon,pickedWeapon);
        PlayerPrefs.SetString(PlayerPrefsStrings.PickedSkin,pickedSkin);
        for (int i = 0; i < gottenWeapons.Count; i++)
        {
            PlayerPrefs.SetInt($"{PlayerPrefsStrings.ShopWeapon}{i}", 1);
        }
        for (int i = 0; i < gottenSkins.Count; i++)
        {
            PlayerPrefs.SetInt($"{PlayerPrefsStrings.ShopSkin}{i}", 1);
        }
    }

    public static void LoadData() 
    {
        currency = PlayerPrefs.GetInt(PlayerPrefsStrings.Currency);
        pickedWeapon = PlayerPrefs.GetString(PlayerPrefsStrings.PickedWeapon);
        pickedSkin = PlayerPrefs.GetString(PlayerPrefsStrings.PickedSkin);
        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.GetInt($"{PlayerPrefsStrings.ShopWeapon}{i}",0)==1)
            {
                gottenWeapons.Add(i);
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.GetInt($"{PlayerPrefsStrings.ShopSkin}{i}", 0) == 1)
            {
                gottenSkins.Add(i);
            }
        }
    }
}

public struct PlayerPrefsStrings 
{
    public static string Currency = "Currency";
    public static string ShopSkin = "ShopSkin";
    public static string ShopWeapon = "ShopWeapon";
    public static string PickedSkin = "PickedSkin";
    public static string PickedWeapon = "PickedWeapon";
}




