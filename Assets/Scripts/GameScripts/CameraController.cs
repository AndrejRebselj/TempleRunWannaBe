using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    public Vector3 offset;
    void Start()
    {
        player = GameObject.Find("Player");
    }
    private void FixedUpdate()
    {
        if (player != null) 
        {
            transform.position = new Vector3(
                player.transform.position.x+offset.x, 
                player.transform.position.y+offset.y, 
                player.transform.position.z+offset.z
                );
        }
    }
}
