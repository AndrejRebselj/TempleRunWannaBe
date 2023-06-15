using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGettingHitController : MonoBehaviour
{
    public static event Action BonusIsGettingHit;

    private void OnTriggerEnter(Collider other)
    {
        BonusIsGettingHit?.Invoke();
    }
}
