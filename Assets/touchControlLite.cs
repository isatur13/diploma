using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchControlLite : MonoBehaviour {

    Touch touch;
    CharacterController player;
    public float maxSpeed;
    public float jumpForce;
    float verticalVelocity;
    Vector3 moveDir;
    Animator anim;

	// Use this for initialization
	void Start () {
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        anim.SetBool("isWalking", true);

        if (player.isGrounded)
        {
            verticalVelocity += Physics.gravity.y;
            if (Input.touchCount > 0)
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity += Physics.gravity.y;
        }

        moveDir = new Vector3(0f, verticalVelocity * Time.deltaTime, maxSpeed * Time.deltaTime);
        player.Move(moveDir);
	}
}
