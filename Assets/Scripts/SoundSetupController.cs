using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetupController : MonoBehaviour
{
    AudioSource music;
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.volume = PlayerPrefs.GetFloat("SoundVolume", 1);
    }
}
