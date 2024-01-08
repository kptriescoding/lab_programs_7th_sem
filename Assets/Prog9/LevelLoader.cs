using System.Collections;
using System.Collections.Generic;
using UnityEngine;






//Imppppppppppppppppppp v v Imppp
//Immmmmmmmmmmmmmmmm
//imm import
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject levelText;
    public Slider slider;
    public Text loadingText;
    public void changeLevel(int index){
        StartCoroutine(updateProgress(index));
    }
    IEnumerator updateProgress(int index){
        levelText.SetActive(false);
        for(int i=0;i<10;i++){
            slider.value=i/10f;
            loadingText.text=i*10+" %";
            yield return new WaitForSeconds(1f);
        }
        SceneManager.LoadScene(index);
    }
}
