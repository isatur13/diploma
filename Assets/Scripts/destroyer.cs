using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {

    public GameObject player;
    public CharacterController playerCollider;
    Component move;
    bool hasKey;
    public bool playerNear;
    bool moved;
    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
        moved = false;
        playerNear = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        hasKey = player.GetComponent<move>().hasKey;
        if (hasKey && !moved)
        {
            transform.Rotate(new Vector3(0, 0, -90));
            transform.Translate(new Vector3(3.5f,5.5f,0));
            moved = true;
        }
	}
    
}
