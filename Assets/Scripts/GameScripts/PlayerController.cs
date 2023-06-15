using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    GameObject playerObject;
    Animator playerAnimator;
    Vector2 startTouchPosition;
    Vector2 endTouchPosition;
    void Start()
    {
        playerAnimator = playerObject.GetComponent<Animator>();
        playerRigidbody = playerObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        //calculate touch start/end position
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) startTouchPosition = Input.GetTouch(0).position;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            //get swipe direction
            if (endTouchPosition.x < startTouchPosition.x)
            {
                //jump to left
                playerAnimator.SetTrigger("Jump");
                playerRigidbody.AddForce((Vector3.up + Vector3.left) * jumpForce, ForceMode.Impulse);
            }
            if (endTouchPosition.x > startTouchPosition.x)
            {
                //jump to right
                playerAnimator.SetTrigger("Jump");
                playerRigidbody.AddForce((Vector3.up + Vector3.right) * jumpForce, ForceMode.Impulse);
            }
        }
        
        /*if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            //jump to right
            playerAnimator.SetTrigger("Jump");
            playerRigidbody.AddForce((Vector3.up + Vector3.right) * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //jump to left
            playerAnimator.SetTrigger("Jump");
            playerRigidbody.AddForce((Vector3.up + Vector3.left) * jumpForce, ForceMode.Impulse);
        }*/


    }
}
