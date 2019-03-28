using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour {

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
    public bool hasKey =  false;
    private Rigidbody rb;
    public float gravityMultiplier;
    public gameState gameState;
    public enterCave enterCave;
    public Transform CaveEntry;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        jumpPowerUp = false;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
        
    {
        
        if (Input.GetAxis("Horizontal") != 0){
            anim.SetBool("isWalking", true);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("isWalking", false);
        }
        if (controller.isGrounded)
        {
            anim.SetBool("isJumping", false);
            if (Input.GetButtonDown("Jump"))
            {
                
                if (!jumpPowerUp)
                    verticalVelocity = jumpForce;
                else
                    verticalVelocity = jumpPowerUpForce;
            }
        }
        
        else
        {
            anim.SetBool("isJumping", true);
            verticalVelocity += Physics.gravity.y*gravityMultiplier *Time.deltaTime;
        }
        
        moveDirection = new Vector3(0, verticalVelocity * Time.deltaTime, Input.GetAxis("Horizontal") * maxSpeed*Time.deltaTime);
        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection);
        anim.SetFloat("vertVel", verticalVelocity);
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
        if(pushingObject == null || hit.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            return;
        }
        if(hit.moveDirection.y < -0.5)
        {
            return;
        }
        pushingObject.velocity = new Vector3(0,0,hit.moveDirection.z * pushingForce); 

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            hasKey = true;
        }
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
        
        if(other.gameObject.CompareTag("Trap"))
        {
            gameState.GameOver();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CaveEntry") && transform.position.z > CaveEntry.position.z)
        {
            enterCave.inCave = true;
        }
        else if(other.CompareTag("CaveEntry") && transform.position.z < CaveEntry.position.z)
        {
            enterCave.inCave = false;
        }
    }
}
