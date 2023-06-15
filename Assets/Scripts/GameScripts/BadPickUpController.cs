using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPickUpController : MonoBehaviour
{
    public static event Action BadObjectIsPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        BadObjectIsPickedUp?.Invoke();
        gameObject.SetActive(false);
    }
}
