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
    public Text levelText;
    public Slider slider;
    public Text loadingText;
    public void changeLevel(int index){
        StartCoroutine(updateProgress(index));
    }
    IEnumerator updateProgress(int index){
        AsyncOperation operation=SceneManager.LoadSceneAsync(index);
        levelText.enabled=false;
        slider.enabled=true;
        while(!operation.isDone){
            float progress=Mathf.Clamp01(operation.progress/0.9f);
            slider.value=progress;
            loadingText.text=progress*100+"%";

            yield return null;
        }
    }
}
