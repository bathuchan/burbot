using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDUpdate : MonoBehaviour
{
    public int numberOfScraps;
    public Text _scrapNumberText;
    PlayerInventory inventory;
    private GameObject gameManager;

    private void Awake()
    {//GameObject go = GameObject.Find("GameManager").GetComponent<PlayerInventory>().gameObject;
        gameManager = GameObject.Find("GameManager").gameObject;
        gameManager.TryGetComponent<PlayerInventory>(out inventory);
        this.numberOfScraps = inventory.numberOfScraps;
        UpdateUI();
        if (SceneManager.GetActiveScene().name == "Factory") 
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }
    }
   
    public void ScrapCollected(int amount)
    {
        numberOfScraps = numberOfScraps + amount;
        inventory.numberOfScraps = numberOfScraps;
        UpdateUI();
    }
    public bool ScrapRemoved(int i)
    {
        if (numberOfScraps >= i)
        {
            numberOfScraps = numberOfScraps - i;
            inventory.numberOfScraps = numberOfScraps;
            UpdateUI();
            return true;
        }
        else
        {
            return false;
        }

    }
    private void UpdateUI()
    {
        string a = numberOfScraps.ToString();
        _scrapNumberText.text = a + "x";

    }
}
