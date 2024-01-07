using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking",false);
        animator.SetBool("isJumping",false);
        animator.SetBool("isSprinting",false);
        animator.SetBool("isDancing",false);

        if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.LeftShift)){
            animator.SetBool("isSprinting",true);
        }
        else if(Input.GetKey(KeyCode.W)){
            animator.SetBool("isWalking",true);
        }
        else if(Input.GetKey(KeyCode.Space)){
        animator.SetBool("isJumping",true);

        }
        else if(Input.GetKey(KeyCode.X)){
        animator.SetBool("isDancing",true);

        }
    }
}
