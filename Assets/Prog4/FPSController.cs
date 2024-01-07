using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController: MonoBehaviour
{

    private Vector2 mouseInput;
    private float xRot;
    private Rigidbody rigidbody;
    private Transform camera;
    private float Speed=5;
    private float Sensitivity=1;
    private float JumpForce=5;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidbody=GetComponent<Rigidbody>();
        camera=GetComponentInChildren<Camera>().transform;
        
    }

  

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        MovePlayerCamera();

    }

    private void MovePlayer() 
    {   
        float travelSpeed=Speed;
        if(Input.GetKey(KeyCode.LeftShift)){
            travelSpeed*=2;
        }
        Vector3 MoveVector = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"))) * travelSpeed;
        
        rigidbody.velocity = new Vector3(MoveVector.x, rigidbody.velocity.y, MoveVector.z);

        if (Input.GetKeyDown(KeyCode.Space)) 
        {   
                rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
            
    }

    private void MovePlayerCamera ()
    {   
        mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        xRot -= mouseInput.y * Sensitivity;
        xRot = Mathf.Clamp(xRot, -90f, 90f); 


        transform.Rotate(0f, mouseInput.x * Sensitivity, 0f);
        camera.transform.localRotation = Quaternion.Euler(xRot, 0f ,0f);
    }
}