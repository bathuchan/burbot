using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public TransitionSettings transition;
    public float LoadDelay;
    public string _sceneToLoad;
    public string currentTheme= "Theme1", nextTheme= "Theme2";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            LoadScene(_sceneToLoad);
            
            //FindObjectOfType<AudioManager>().Play("ValveSound");
            //FindObjectOfType<AudioManager>().Play("ValveSound");
        }
            

    }
    public void LoadScene(string s)
    {
        TransitionManager.Instance().Transition(s, transition, LoadDelay);
        FindObjectOfType<AudioManager>().FadeOut(currentTheme/*"Theme1"*/);
        
        FindObjectOfType<AudioManager>().FadeIn(nextTheme/*"Theme2"*/);
    }

   
}
