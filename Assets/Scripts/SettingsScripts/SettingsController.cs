using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    MyButton controller;
    AudioSource audioSource;
    void Start()
    {
        MyLabel sound = new MyLabel("SoundText");
        sound.SetText("Volume");
        controller = new MyButton("Control");
        SetKownOption();
        controller.OnClick(delegate { ChangeControllerOption(); });
        MyButton retButton = new MyButton("Return");
        retButton.SetText("Return");
        retButton.OnClick(delegate { NavigationFramework.RemoveViewNode(); });
        slider.value = PlayerPrefs.GetFloat("SoundVolume", 1f);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = slider.value;
        slider.onValueChanged.AddListener(delegate { SaveNewValu(); });
        
    }

    private void SetKownOption()
    {
        if (PlayerPrefs.GetInt("Controller",1) == 1)
        {
            controller.SetText("Controller ON");
            PlayerPrefs.SetInt("Controller", 1);
        }
        else
        {
            controller.SetText("Controller OFF");
        }
    }

    private void ChangeControllerOption()
    {
        if (PlayerPrefs.GetInt("Controller")==1)
        {
            controller.SetText("Controller OFF");
            PlayerPrefs.SetInt("Controller",0);
        }
        else
        {
            controller.SetText("Controller ON");
            PlayerPrefs.SetInt("Controller", 1);
        }
    }

    private void SaveNewValu()
    {
        PlayerPrefs.SetFloat("SoundVolume",slider.value);
        audioSource.volume = slider.value;
    }
}
