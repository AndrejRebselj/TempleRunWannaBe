using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLogicController : MonoBehaviour
{
    [SerializeField]
    GameObject weaponHolder;
    [SerializeField]
    int scaleNumb=10;
    GameObject weapon;
    private void Start()
    {
        Transform[] trans = weaponHolder.GetComponentsInChildren<Transform>();
        weapon = trans[1].gameObject;
        PickUpController.ObjectIsPickedUp += PickUpEvent;
        BadPickUpController.BadObjectIsPickedUp += BadPickUpEvent;
    }

    private void BadPickUpEvent()
    {
        weapon.transform.localScale = new Vector3(weapon.transform.localScale.x, weapon.transform.localScale.y - scaleNumb, weapon.transform.localScale.z);
    }

    private void PickUpEvent()
    {
        weapon.transform.localScale = new Vector3(weapon.transform.localScale.x, weapon.transform.localScale.y+scaleNumb, weapon.transform.localScale.z);
    }

    private void OnDestroy()
    {
        PickUpController.ObjectIsPickedUp -= PickUpEvent;
        BadPickUpController.BadObjectIsPickedUp -= BadPickUpEvent;
    }
}
