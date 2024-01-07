using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    private int up=1;
    public float speed=1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>5)
            up=-1;
        if(transform.position.y<-5)
            up=1;
        transform.Translate(up*Vector3.up*Time.deltaTime*speed);
    }
}
