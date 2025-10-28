using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : MonoBehaviour
{
   
    public int numberOfScraps;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
       
    }


}
