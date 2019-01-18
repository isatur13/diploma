using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phoneController : MonoBehaviour {

    public float maxSpeed;
    bool facingRight = true;
    public float jumpForce;
    Animator anim;
    Vector3 moveDirection;
    CharacterController controller;
    public float pushingForce;
    Rigidbody pushingObject;
    float verticalVelocity;
    bool jumpPowerUp;
    public float jumpPowerUpForce;
    public bool hasKey = false;
    public bool jump;
    public bool moveRight;
    public bool moveLeft;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        jumpPowerUp = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (!controller.isGrounded)
        {
            verticalVelocity += Physics.gravity.y;
        }
        
        if (moveDirection.z > 0 && !facingRight)
        {
            Flip();
        }
        if (moveDirection.z < 0 && facingRight)
        {
            Flip();
        }
        moveDirection.y = verticalVelocity * Time.deltaTime;
        controller.Move(moveDirection);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }

    public void MoveRight(bool move)
    {
        if (move)
        {
            moveDirection.z = maxSpeed * Time.deltaTime;
            anim.SetBool("isWalking", true);
        }
    }

    public void MoveLeft(bool move)
    {
        if (move)
        {
            moveDirection.z = -maxSpeed * Time.deltaTime;
            anim.SetBool("isWalking", true);
        }
    }

    public void Jump(bool jump)
    {
        if (controller.isGrounded)
        {
            if (jump)
            {
                if (jumpPowerUp)
                    verticalVelocity = jumpPowerUpForce;
                else
                    verticalVelocity = jumpForce;
            }
        }
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Power Up"))
        {
            other.gameObject.SetActive(false);
            jumpPowerUp = true;
        }
        if (other.gameObject.CompareTag("Power Down"))
        {
            other.gameObject.SetActive(false);
            jumpPowerUp = false;
        }
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            hasKey = true;
        }
    }
}

