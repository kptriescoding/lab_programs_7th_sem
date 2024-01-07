using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    Light light;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        light=GetComponent<Light>();
        material=GetComponent<Renderer>().material;
    }
    void OnMouseDown(){
Color color=Random.ColorHSV();
        light.color=color;
        material.color=color;
    }

    // Update is called once per frame

}
