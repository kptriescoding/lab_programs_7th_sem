using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Imppppppppppppppppppp v v Imppp
//Immmmmmmmmmmmmmmmm
//imm import

using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
  
    // Start is called before the first frame update

  private Animator animator;

//import both these
  //using UnityEngine.SceneManagement;
//using UnityEngine.UI;
    public Slider slider;
    public Text text,hpText;
    void Start()
    {
        animator=GetComponent<Animator>();
        animator.SetBool("isDead",false);
    }

    //import both these
  //using UnityEngine.SceneManagement;
//using UnityEngine.UI;
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("GetHit")&&animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            animator.SetBool("isHit",false);
    }


    //import both these
  //using UnityEngine.SceneManagement;
//using UnityEngine.UI;
     void OnMouseDown(){
        slider.value=(slider.value-0.1f);
        hpText.text="HP: "+Mathf.Round(slider.value*100)+"%";
        if(slider.value==0f){
            animator.SetBool("isDead",true);
            text.text="He has Died";
        }
        else
            animator.SetBool("isHit",true);
    }
}
