﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fckimove : MonoBehaviour {

    public Rigidbody rb;

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(new Vector3(100.0f, 0));
	}
}
