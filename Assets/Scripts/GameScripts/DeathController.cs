using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    [SerializeField]
    GameObject deathMenu;
    void Start()
    {
        MyButton retry = new MyButton("Retry");
        MyButton quit = new MyButton("QuitDeath");
        deathMenu.SetActive(false);

        retry.SetText("Retry");
        quit.SetText("Quit");

        retry.OnClick(() => {
            Time.timeScale = 1.0f;
            NavigationFramework.ReloadViewNode();

        });
        quit.OnClick(() => {
            Time.timeScale = 1.0f;
            NavigationFramework.RemoveViewNode();
        });
        DeathTriggerOnObject.deathIsTriggered += deathTime;

    }

    private void deathTime()
    {
        Time.timeScale =0f;
        deathMenu.SetActive(true);
    }

    private void OnDestroy()
    {
        DeathTriggerOnObject.deathIsTriggered -= deathTime;
    }
}
