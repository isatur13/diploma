using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour {

    public GameObject player;
    Component move;
    public bool hasKey;
    Transform door;
    bool moved = false;

	// Use this for initialization
	void Start () {
        door = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        
        hasKey = player.GetComponent<move>().hasKey;
        if (hasKey == true && moved == false)
        {
            door.Rotate(new Vector3(0, 0, -90));
            door.Translate(new Vector3(3,2,0));
            moved = true;
        }
	}
    
}
