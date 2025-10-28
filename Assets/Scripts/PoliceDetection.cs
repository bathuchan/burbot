using Cinemachine;
using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoliceDetection : MonoBehaviour
{
    public GameObject deathFX;
    public TransitionSettings transition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player") 
        {
            Instantiate(deathFX, other.transform.position, other.transform.rotation);
            GameObject player= other.gameObject;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            player.GetComponent<PlayerMovement>().enabled=false;
            FindObjectOfType<CinemachineVirtualCamera>().Follow=null;


            FindObjectOfType<AudioManager>().Play("DeathSound");
            FindObjectOfType<AudioManager>().Stop("Theme1");
            FindObjectOfType<AudioManager>().Stop("Theme2");

            Time.timeScale = 0.7f;
            StartCoroutine(Disable(other));
           
        }
    }

    IEnumerator Disable(Collider other) 
    {
        yield return new WaitForSeconds(2f);
        //other.gameObject.SetActive(false);
        string currentSceneName = SceneManager.GetActiveScene().name;
        LoadScene(currentSceneName);
        if (currentSceneName == "City")
        {
            FindObjectOfType<AudioManager>().FadeIn("Theme1");
            /*if (GameObject.Find("GameManager").transform.TryGetComponent<PlayerInventory>(out PlayerInventory inv))
            {
                if (inv.numberOfScraps > 10)
                {
                    inv.numberOfScraps = inv.numberOfScraps - 10;
                }
                else
                {
                    inv.numberOfScraps = inv.numberOfScraps - inv.numberOfScraps;
                }
            }*/
            Destroy(GameObject.Find("GameManager"));

        } else if (currentSceneName == "Factory")
        {
            FindObjectOfType<AudioManager>().FadeIn("Theme2");
        } 
        Time.timeScale = 1f;

        yield return null;
    }
    public void LoadScene(string s)
    {
        TransitionManager.Instance().Transition(s, transition, 0.3f);
        
    }
}
