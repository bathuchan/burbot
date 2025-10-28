using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityQuestObjectives : MonoBehaviour
{
    [SerializeField] private int totalTraficLights=0;
    [SerializeField] public int fixedTrafficLights = 0;
    [SerializeField]private int totalCCTV=0;
    public int fixedCCTV = 0;
    private bool done=true;
    bool doOnce1=true;
    bool doOnce2 = true;
    
    private void Start()
    {
        totalCCTV = GameObject.Find("/Kameralar").transform.childCount;

        totalTraficLights = GameObject.Find("/TrafikLambalari").transform.childCount;
    }
    [SerializeField] private bool lightQuest=false;
    [SerializeField] private bool CCTVQuest = false;

    private void FixedUpdate()
    {
        if (fixedCCTV == totalCCTV&& doOnce1) 
        {
            CCTVQuest=done;
            doOnce1 = false;
            Debug.Log("CCTVquest=" + CCTVQuest);
        }
        if (fixedTrafficLights==totalTraficLights && doOnce2) 
        {
            lightQuest=done;
            doOnce2=false;
            Debug.Log("Lightquest=" + lightQuest);
        }

        if (CCTVQuest && lightQuest) 
        {
            GameObject.Find("ArrowGameObject").GetComponent<ArrowRotate>().SetTargettoFactoryt();
            //doOnce3 = false;
        }
    }

}
