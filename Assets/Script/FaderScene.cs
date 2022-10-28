using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FaderScene : MonoBehaviour
{
    private string sceneToLoad;
    private Image theImage;
    public float transitionSpeed;
    private bool isDisplay; 
    // Start is called before the first frame update
    void Start()
    {
        theImage = GetComponent<Image>();
        isDisplay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDisplay){
            theImage.material.SetFloat("_CutOff", Mathf.MoveTowards(theImage.material.GetFloat("_CutOff"), 1.1f, transitionSpeed * Time.unscaledDeltaTime));
        }
        else {
            theImage.material.SetFloat("_CutOff", Mathf.MoveTowards(theImage.material.GetFloat("_CutOff"), -0.1f - theImage.material.GetFloat("_Smoothing"), transitionSpeed * Time.unscaledDeltaTime));

            if(theImage.material.GetFloat("_CutOff") == -0.1f - theImage.material.GetFloat("_Smoothing")){
                SceneManager.LoadScene(sceneToLoad);
            }
        }

    }

    public void SceneLoad(string sceneName){
        sceneToLoad = sceneName;
        isDisplay = false;
    }
}
