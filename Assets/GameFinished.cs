using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinished : MonoBehaviour
{
    
    public GameObject congrats;
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        congrats.SetActive(true);


    }
}
