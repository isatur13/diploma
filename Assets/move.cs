using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    public float maxSpeed = 10f;
    bool facingRight = true;
    public float jumpForce = 500f;
    Animator anim;
    Vector3 moveDirection;
    CharacterController controller;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
	
    void Update()
        
    {
        moveDirection = new Vector3(0,0,Input.GetAxis("Horizontal")*maxSpeed);
        
        if (moveDirection.z != 0){
            anim.SetBool("isWalking", true);
        }
        if (moveDirection.z == 0)
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            moveDirection.y = jumpForce;
        }

            moveDirection += Physics.gravity;
            controller.Move(moveDirection *  Time.deltaTime);

        if (moveDirection.z > 0 && !facingRight)
        {
            Flip();
        }
        if (moveDirection.z < 0 && facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }
}
