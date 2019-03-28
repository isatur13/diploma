using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pullObjects : MonoBehaviour
{
    public Transform raycaster;
    public float distance = 1.0f;
    public LayerMask pullable;
    RaycastHit hit;
    Rigidbody player;
    GameObject box;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(raycaster.position, Vector3.forward * transform.lossyScale.z, out hit, distance, pullable))
        {
            if (hit.collider.CompareTag("Pullable") && Input.GetKeyDown(KeyCode.P))
            {
                box = hit.collider.gameObject;
                box.GetComponent<FixedJoint>().connectedBody = player;
            }
        }
        if (box !=null && (Input.GetKeyUp(KeyCode.P) || Input.GetButtonDown("Jump")))
        {
            box.GetComponent<FixedJoint>().connectedBody = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(raycaster.position, transform.position + Vector3.forward * transform.lossyScale.z *distance);
    }
}
