using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    [SerializeField]
    GameObject endScreen;
    public static event Action EndGame;
    public static bool IsAddDone = false;

    private void Start()
    {
        MyButton quit = new MyButton("GameOverQuit");
        endScreen.SetActive(false);
        quit.SetText("Quit");
        quit.OnClick(() =>
        {
            Time.timeScale = 1.0f;
            NavigationFramework.RemoveViewNode();
            EndGame?.Invoke();
        });
        BonusPointsController.WeaponIsDone += StartEndScreen;
    }

    private void StartEndScreen()
    {
        endScreen.SetActive(true);
    }

    private void OnDestroy()
    {
        BonusPointsController.WeaponIsDone -= StartEndScreen;
    }
}
