using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class ArrowRotate : MonoBehaviour
{
    [SerializeField] public List<GameObject> Targets = new List<GameObject>();
    public float Speed=1f;
    public bool Visable;

    Vector3 LookingAt;

    private GameObject Arrow;
    
    public bool doItOnce=true;
    

    public Transform Factory;


    private void Start()
    {
        Arrow=this.gameObject.transform.GetChild(0).gameObject;
        //LookingAt = Targets[0].transform.position;
        

    }

    private void Update()
    {

        if (Targets.Count!=0) 
        {
            if (doItOnce) 
            {
                LookingAt= CurrentTarget(Targets);
                doItOnce = false;
            }
            
            if (Visable)
            {
                //this.enabled = true;
                //Renderer.enabled = true;
                transform.LookAt(LookingAt);
                Arrow.SetActive(true);
            }
            else
            {
                //enabled = false;
                //Renderer.enabled = false;   
                Arrow.SetActive(false);
            }

        }
        
        
        
    }

    private Vector3 CurrentTarget(List<GameObject> list) 
    {

        
        //GameObject go = list[i];
        foreach (GameObject go in list) 
        {
            
            
            if (go.TryGetComponent<CCTV>(out CCTV objectsStat)) //
            {
                
                if (objectsStat.isFixed)
                {
                    
                    continue;
                }
                else
                {
                    Debug.Log(objectsStat);

                    
                    return go.transform.position;
                    
                    
                      
                }
            } //else if () { }
            
        }
        return new Vector3();
    }

    public void SetTargettoFactoryt() 
    {
        Factory.gameObject.SetActive(true);
        LookingAt = Factory.transform.position;
    }

}
