using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody rigidbody;
    public float _speed;
    void Start(){
        rigidbody=GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(0,-1,0)*_speed*50,ForceMode.Impulse);

    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-40){
            transform.position=new Vector3(0,8,0);
            rigidbody.velocity=Vector3.zero;
            rigidbody.AddForce(new Vector3(0,-1,0)*_speed*50,ForceMode.Impulse);
        }
    }
}
