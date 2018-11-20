using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightControl : MonoBehaviour {

    Transform right;
    public Transform player;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        right = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        right.position = player.position + offset;
	}
}
