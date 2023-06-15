using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public static event Action ObjectIsPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        ObjectIsPickedUp?.Invoke();
        gameObject.SetActive(false);
    }
}
