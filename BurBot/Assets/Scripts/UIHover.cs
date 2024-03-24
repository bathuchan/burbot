using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHover : MonoBehaviour
{
    
    
    static GameObject Panel;

    private void Awake()
    {
        Panel = this.gameObject;
        //HidePanel();
    }
    public void ShowPanel() 
    {
        if (Panel != null) 
        {
            GameObject a;

            //Panel.SetActive(false);
            Panel.GetComponent<Image>().enabled = true;
            a = Panel.transform.GetChild(0).gameObject;
            a.SetActive(true);
            /*Panel.GetComponent<Image>().enabled=true;
            Panel.transform.GetChild(0).GetComponent<Image>().enabled = true;//?
            Panel.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().enabled = true;
            Panel.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().enabled = true;*/
        }
    }

    public void HidePanel()
    {
        if (Panel != null)
        {
            GameObject a;
            
            //Panel.SetActive(false);
            Panel.GetComponent<Image>().enabled = false;
            a = Panel.transform.GetChild(0).gameObject;
            a.SetActive(false);/*
            //aImage.enabled = false;
            //?
            Panel.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().enabled = false;
            Panel.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().enabled = false;*/
        }
    }

}
