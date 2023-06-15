using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerOnObject : MonoBehaviour
{
    public static event Action deathIsTriggered;

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space)) deathIsTriggered?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        deathIsTriggered?.Invoke();
    }
}
