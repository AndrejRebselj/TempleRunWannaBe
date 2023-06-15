using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSoundSetup : MonoBehaviour
{
    [SerializeField]
    GameObject soundController;
    AudioSource[] audioSources;
    void Start()
    {
        audioSources = soundController.GetComponents<AudioSource>();
        audioSources[2].volume = PlayerPrefs.GetFloat("SoundVolume", 1f);
        PickUpController.ObjectIsPickedUp += PickUpSoundEvent;
        BadPickUpController.BadObjectIsPickedUp += BadPickUpSoundEvent;
    }

    private void BadPickUpSoundEvent()
    {
        audioSources[1].Play();
    }

    private void PickUpSoundEvent()
    {
        audioSources[0].Play();
    }

    private void OnDestroy()
    {
        PickUpController.ObjectIsPickedUp -= PickUpSoundEvent;
        BadPickUpController.BadObjectIsPickedUp -= BadPickUpSoundEvent;
    }
}
