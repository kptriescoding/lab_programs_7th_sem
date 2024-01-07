using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lineRenderer;
    private Material material;
    void Start()
    {
        lineRenderer=GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"),0f));
        if(Input.GetKey(KeyCode.Space)){
            lineRenderer.enabled=true;
        lineRenderer.SetPosition(0, transform.position+new Vector3(0,0.2f,0));
        lineRenderer.SetPosition(1, transform.position + transform.forward * 15f+new Vector3(0,0.2f,0));
        Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*15f);
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out RaycastHit hit,15f))
        {
            Debug.Log("Object: "+hit.collider.name+"\n\n"+"Distance: "+hit.distance+"\n\n"+"Position: "+hit.transform.position);
            material=hit.transform.GetComponent<Renderer>().material;
            if(material.color==Color.blue)
                material.color=Color.white;
            else
                material.color=Color.blue;
        }
        }
        else{
            lineRenderer.enabled=false;
        }
    }
}
