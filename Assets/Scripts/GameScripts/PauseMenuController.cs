using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    MyButton startPauseButton;
    MyButton resumeButton;
    MyButton quitButton;
    [SerializeField]
    GameObject panelObject;
    void Start()
    {
        startPauseButton = new MyButton("PauseButton");
        resumeButton = new MyButton("Resume");
        resumeButton.SetText("Resume");
        quitButton = new MyButton("Quit");
        quitButton.SetText("Quit");
        startPauseButton.OnClick(() => {
            PauseTheGame();
        });
        resumeButton.OnClick(() => {
            UnpauseTheGame();
        });
        quitButton.OnClick(() => {
            Time.timeScale = 1.0f;
            NavigationFramework.RemoveViewNode();
        });
        panelObject.SetActive(false);
    }

    private void UnpauseTheGame()
    {
        panelObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void PauseTheGame()
    {
        panelObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
