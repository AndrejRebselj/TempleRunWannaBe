using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndTrigger : MonoBehaviour
{
    public static event Action GameEndTriggered;

    private void OnTriggerEnter(Collider other)
    {
        GameEndTriggered?.Invoke();
        gameObject.SetActive(false);
    }
}
