using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndingController : MonoBehaviour
{
    [SerializeField]
    GameObject camera;
    [SerializeField]
    Animator player;
    Transform cameraTransform;
    CameraController ccontroller;
    CharacterController characterController;
    void Start()
    {
        cameraTransform = camera.GetComponent<Transform>();
        ccontroller = camera.GetComponent<CameraController>();
        characterController = GetComponent<CharacterController>();
        GameEndTrigger.GameEndTriggered += GameEndingHit;
    }

    private void GameEndingHit()
    {
        player.SetBool("Ending",true);
        characterController.enabled = false;
        cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.x, cameraTransform.rotation.y - 75, cameraTransform.rotation.z - 15);
        ccontroller.offset = new Vector3(10, 5, -2);
    }

    private void OnDestroy()
    {
        GameEndTrigger.GameEndTriggered -= GameEndingHit;
    }
}
