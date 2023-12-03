using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prog1 : MonoBehaviour
{
    public float _speed=0.1f;
    void Update()
    {
        if(Input.mouseScrollDelta.y>0){
            transform.localScale+=Vector3.up*_speed;
        }
if(Input.mouseScrollDelta.y<0){
            transform.localScale+=Vector3.down*_speed;
        }
        
        if(Input.GetKey(KeyCode.W)){
            transform.position+=Vector3.up*_speed;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position+=Vector3.down*_speed;
        }
        if(Input.GetKey(KeyCode.Q)){
            transform.Rotate(Vector3.forward*_speed*4);
        }
        if(Input.GetKey(KeyCode.E)){
            transform.Rotate(Vector3.back*_speed*4);
        }

    }
}
