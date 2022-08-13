using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Store : MonoBehaviour
{
    
    void Start()
    {
        loadCoin();
    }

    private void loadCoin()
    {
        SaveLoad.Load();
        GameObject goldText = GameObject.FindWithTag("GoldText");
        TextMeshProUGUI text = goldText.GetComponent<TextMeshProUGUI>();
        text.text = SaveData.coin.ToString();
    }

    private bool isCoinEnough(float price){
        if(SaveData.coin < price)
            return false;
        return true;
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
