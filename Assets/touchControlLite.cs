using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touchControlLite : MonoBehaviour {

    Touch touch;
    CharacterController player;
    public float maxSpeed;
    public float jumpForce;
    float verticalVelocity;
    Vector3 moveDir;
    Animator anim;
    public Button rightbtn;
    public Button leftbtn;
    public Button jumpbtn;

	// Use this for initialization
	void Start () {
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rightbtn.onClick.AddListener(delegate { changeText(rightbtn); });
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        

        if (player.isGrounded)
        {
            verticalVelocity += Physics.gravity.y;
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                Debug.Log(touch.position.x);

                if (touch.position.x > 800f)
                {
                    Debug.Log("Nobi");
                    anim.SetBool("isWalking", true);
                }
            }
        }
        else
        {
            verticalVelocity += Physics.gravity.y;
        }

        moveDir = new Vector3(0f, verticalVelocity * Time.deltaTime, 0);
        player.Move(moveDir);
	}
    void changeText(Button btn)
    {
        btn.GetComponentInChildren<Text>().text="changes";
    }
}
