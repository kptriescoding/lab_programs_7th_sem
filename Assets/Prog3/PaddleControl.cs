using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    public float _speed=0.1f;
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            transform.position+=Vector3.left*_speed;
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position+=Vector3.right*_speed;
        }
    }
}
