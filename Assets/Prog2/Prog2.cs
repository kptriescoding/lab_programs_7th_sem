using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prog2 : MonoBehaviour
{
    public Vector3 startForce;
    private Material material;
    void Start(){
        Rigidbody rigidbody =GetComponent<Rigidbody>();
        rigidbody.AddForce(startForce,ForceMode.Impulse);
        material=(GetComponent<Renderer>()).material;
    }
    void OnCollisionEnter(Collision collision){
        switch (collision.gameObject.name)
        {
            case "1":
            material.color=Color.red;
            break;
            case "2":
            material.color=Color.yellow;
            break;
            case "3":
            material.color=Color.blue;
            break;
            case "4":
            material.color=Color.green;
            break;
            case "5":
            material.color=Color.black;
            break;
            case "6":
            material.SetColor("_Color",Color.cyan);
            break;
            default:
            break;
        }
    }
}
