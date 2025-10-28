using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;

    [HideInInspector] public bool isFixed=false;
    public List<GameObject> stopedCars;

    public bool Interact(Interaction interaction)
    {
        GameObject hud = GameObject.Find("HUD");
       if (hud != null && hud.TryGetComponent<HUDUpdate>(out HUDUpdate act)&& !isFixed) 
        {
            if (act != null&& act.numberOfScraps>=5) 
            {
                act.ScrapRemoved(5);
                isFixed = true;
                _prompt = "Bu cihaz tamir edildi.";

                


                GetComponent<Animator>().SetBool("IsFixed", isFixed);

                FindObjectOfType<AudioManager>().Play("CCTVfixed");
                if (GameObject.Find("QuestManager").TryGetComponent<CityQuestObjectives>(out CityQuestObjectives cityQuest)) 
                {
                    if (this.tag == "CCTV")
                    {
                        transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                        transform.GetChild(3).GetChild(3).gameObject.SetActive(false);

                        transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
                        cityQuest.fixedCCTV++;
                    } else if (this.tag=="TrafficLight") 
                    {
                        transform.GetChild(3).GetChild(0).gameObject.SetActive(false);
                        transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
                        transform.GetChild(3).GetChild(3).gameObject.SetActive(false);

                        
                        cityQuest.fixedTrafficLights++;


                        foreach (GameObject car in stopedCars) 
                        {
                            if (car.gameObject.TryGetComponent<PatrolController>(out PatrolController way)) 
                            {
                                way.EnableMovement = true;
                                car.gameObject.GetComponent<Rigidbody>().isKinematic=false;
                            }
                        }


                    }
                    
                }
                if (GameObject.Find("ArrowGameObject").TryGetComponent<ArrowRotate>(out ArrowRotate aha))
                {
                    aha.doItOnce = !aha.doItOnce;
                }


            }
            else
            {
                _prompt = "Tamir için yetersiz hurda!(5)";
                FindObjectOfType<AudioManager>().Play("ErrorSound");
            }
            
        }
        return true;
    }
}
