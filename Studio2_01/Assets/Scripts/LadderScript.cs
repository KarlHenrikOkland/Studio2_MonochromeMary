using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public Transform player;
    bool climbing = false;
    public float climbingSpeed = 4.0f;
    public FirstPersonLook3 controller;

    // Start is called before the first frame update
    void Start()
    {
        
        climbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(climbing == true && Input.GetKey("r"))
        {
            controller.transform.position += Vector3.up / climbingSpeed;
        }

        if(climbing == true && Input.GetKey("f"))
        {
            controller.transform.position += Vector3.down / climbingSpeed;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            // controller.enabled = false;
            climbing = !climbing;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // controller.enabled = true;
            climbing = !climbing;
        }
    }
}
