using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    float mover;
    [SerializeField]
    GameObject playerObject;

    private void FixedUpdate()
    {
        playerObject.transform.Translate(Vector3.forward * mover * Time.deltaTime);
    }
}
