﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchController : MonoBehaviour {
    public float maxSpeed;
    bool facingRight = true;
    public float jumpForce;
    Animator anim;
    Vector3 moveDirection;
    CharacterController controller;
    public float pushingForce;
    Rigidbody pushingObject;
    float verticalVelocity;
    Touch touch;
    Vector2 touchGamePosition;
    public Transform rightControl;
    float rightControFarBound;
    float rightControlNearBound;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()

    {
        moveDirection = new Vector3(0, 0, Input.GetAxis("Horizontal") * maxSpeed);

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            touchGamePosition = Camera.main.ScreenToWorldPoint(touch.position);
            rightControlNearBound = rightControl.position.x;
            rightControFarBound = rightControl.position.x + rightControl.lossyScale.x;
            if (rightControlNearBound<touchGamePosition.x && touchGamePosition.x < rightControFarBound)
            {
                anim.SetBool("isWalking", true);
            }
            if (Input.GetAxis("Horizontal") == 0)
            {
                anim.SetBool("isWalking", false);
            }
        }
        if (controller.isGrounded)
        {
            verticalVelocity += Physics.gravity.y;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity += Physics.gravity.y;
        }
        moveDirection = new Vector3(0, verticalVelocity * Time.deltaTime, Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime);
        controller.Move(moveDirection);

        if (Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            Flip();
        }
        if (Input.GetAxis("Horizontal") < 0 && facingRight)
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
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        pushingObject = hit.collider.attachedRigidbody;
        if (pushingObject == null || hit.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            return;
        }
        if (hit.moveDirection.y < -0.5)
        {
            return;
        }
        pushingObject.velocity = new Vector3(0, 0, hit.moveDirection.z * pushingForce);

    }
}
