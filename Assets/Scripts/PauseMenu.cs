using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused=false;
    public GameObject pauseMenuUI;
    public GameObject HUD;
    public InputControl inputControl;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(GameIsPaused) 
            {
                Resume();
            }else 
            {
                Pause();
            }
        }
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        inputControl.enabled = true;
        HUD.SetActive(true);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        inputControl.enabled = false;
        HUD.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void QuitGame() 
    {
        Debug.Log("game is closing...");
        Application.Quit();
    }
}
