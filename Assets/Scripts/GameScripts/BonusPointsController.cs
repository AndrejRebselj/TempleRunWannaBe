using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPointsController : MonoBehaviour
{
    [SerializeField]
    GameObject weaponHolder;
    [SerializeField]
    GameObject bonusGiver;
    MeshCollider weaponMesh;
    GameObject weapon;
    public static event Action WeaponIsDone;

    private void Start()
    {
        GameEndTrigger.GameEndTriggered += StartBonusCollecting;
        BonusGettingHitController.BonusIsGettingHit += BonusIsBeingHit;
        Transform[] trans = weaponHolder.GetComponentsInChildren<Transform>();
        weapon = trans[1].gameObject;
        weaponMesh = trans[1].gameObject.GetComponent<MeshCollider>();
    }

    private void BonusIsBeingHit()
    {
        StoreSaver.currency += 2;
        ScoreController.currentScore += 2;
        weapon.transform.localScale = new Vector3(weapon.transform.localScale.x, weapon.transform.localScale.y - 10, weapon.transform.localScale.z);
        if (weapon.transform.localScale.y<=60)
        {
            WeaponIsDone?.Invoke();
        }

    }

    private void StartBonusCollecting()
    {
        weaponMesh.enabled = true;
    }

    private void OnDestroy()
    {
        GameEndTrigger.GameEndTriggered -= StartBonusCollecting;
        BonusGettingHitController.BonusIsGettingHit -= BonusIsBeingHit;
    }
}
