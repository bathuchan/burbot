using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PickUpScrap : MonoBehaviour
{

    public int amount=1;
    HUDUpdate hudUpdate;
    private void Awake()
    {
        GameObject.Find("HUD").TryGetComponent<HUDUpdate>(out hudUpdate);
        
    }
    private void OnTriggerEnter(Collider other)
    {
         
        if (other.CompareTag("Player")) 
        {
            //Debug.Log("toplandi?");
            hudUpdate.ScrapCollected(amount);
            AudioSource s= FindObjectOfType<AudioManager>().Find("ScrapSound");
            s.pitch= Random.Range(0.8f, 1.8f);
            s.Play();
            gameObject.SetActive(false);
            Destroy(gameObject,1f);
        }
    }
}
