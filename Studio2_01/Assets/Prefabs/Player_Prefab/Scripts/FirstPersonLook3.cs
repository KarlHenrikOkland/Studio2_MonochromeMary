using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLook3 : MonoBehaviour
{
    Transform character;
    Vector2 currentMouseLook;
    Vector2 appliedMouseDelta;
    public float sensitivity = 1;
    public float smoothing = 2;
    private float rotX;
    private float rotY;
    public Transform theKey;
  public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    public float turnSpeed = 4.0f;
    public Camera theCam;
    public float pickupDistance = 5.0f;
    public float ScreenPointToRay = 0.0f;

    void Reset()
    {
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
         MouseAiming();

        //  //World pos of where cursor is pointing
        //  Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2f, Screen.height/2f, 0f));
        //  RaycastHit hit;

        //     Debug.DrawRay(ray.origin, ray.direction * pickupDistance, Color.cyan);    
        //  if(Physics.Raycast(ray, out hit, pickupDistance))
        // {
        //     //if we hit something
        //     InteractableAsset obj = hit.collider.GetComponent<InteractableAsset>();
        //     if(obj)
        //     {
        //         sensedObj = obj;
        //     }
        //     else
        //     {
        //         sensedObj = null;
        //     }
        // }
        // else
        // {
        //     //if we did not hit anything
        //     sensedObj = null;
        // }

        // if(Input.GetKeyDown(KeyCode.E) && sensedObj)
        // {
        //     Debug.Log("Hit Object");
        //     //Picked it up
        //     DestroyImmediate(sensedObj.gameObject);
        //     sensedObj = null;

        // }

        
  
  
  
    }



 void MouseAiming()
    {
        // get the mouse inputs
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        
        // rotate the camera
        
        Vector3 camRot = theCam.transform.eulerAngles;
        camRot.x = -rotX;
        theCam.transform.eulerAngles = camRot;
       

        Vector3 body = transform.eulerAngles;
        body.y += y;
        transform.eulerAngles = body;


    }


}
