using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    // Start is called before the first frame update

    public float scrollSpeed;
    public CharacterController player;
    Renderer rend;
    Vector2 offset;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += Time.deltaTime* player.velocity.z* scrollSpeed*0.1f;    
        rend.material.SetTextureOffset("_MainTex",offset);  
    }
}
