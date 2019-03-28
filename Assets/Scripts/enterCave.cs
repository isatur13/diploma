using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterCave : MonoBehaviour
{
    public Light sun;
    public Light[] caveLights;
    public bool inCave;
    public GameObject wall;

    void Start()
    {
        inCave = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inCave)
        {
            sun.enabled = false;
            wall.SetActive(false);
            foreach(Light light in caveLights)
            {
                light.enabled = true;
            }
        }
        else
        {
            sun.enabled = true;
            wall.SetActive(true);
            foreach (Light light in caveLights)
            {
                light.enabled = false;
            }
        }
    }
}
