using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FaderScene : MonoBehaviour
{
    private string sceneName;
    private Image theImage;
    public float transitionSpeed;
    public bool isDisplay;

    // Start is called before the first frame update
    void Awake()
    {
        theImage = GetComponent<Image>();
        isDisplay = true;
    }

    void Update(){
        if(isDisplay){
            theImage.material.SetFloat("_CutOff", Mathf.MoveTowards(theImage.material.GetFloat("_CutOff"), 1.1f, transitionSpeed * Time.unscaledDeltaTime));
        }
        else{
            theImage.material.SetFloat("_CutOff", Mathf.MoveTowards(theImage.material.GetFloat("_CutOff"), -0.1f - theImage.material.GetFloat("_Smoothing"), transitionSpeed * Time.unscaledDeltaTime));

            if(theImage.material.GetFloat("_CutOff") == -0.1f - theImage.material.GetFloat("_Smoothing")){
                SceneManager.LoadScene(sceneName);
            }   
        }
    }

    public void FadeSceneOut(string scene)
	{
        sceneName = scene;
        isDisplay = false;
	}
}
