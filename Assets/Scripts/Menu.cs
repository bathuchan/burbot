using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject howTo;

    public TransitionSettings transition;
    public void OnPlayButton() 
    {
        //TransitionManager.Transition();
        LoadScene("City");
    }

    public void OnHowToButton()
    {
        howTo.SetActive(true);
    }
    public void OnQuitButton() 
    {
        Application.Quit();
    }

    public void LoadScene(string s)
    {
        TransitionManager.Instance().Transition(s, transition, .3f);

    }
}
