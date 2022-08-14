using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Store : MonoBehaviour
{
    public GameObject button;


    void Start()
    {
        SaveLoad.Load();
        loadCoin();
    }


    private void loadCoin()
    {
        SaveLoad.Load();
        GameObject goldText = GameObject.FindWithTag("GoldText");
        TextMeshProUGUI text = goldText.GetComponent<TextMeshProUGUI>();
        text.text = SaveData.coin.ToString();
    }

    public void isCoinEnough(int price){
        if (SaveData.coin < price)            
            return;

        SaveData.coin -= price;
        SaveLoad.Save();
        loadCoin();
        button.gameObject.SetActive(false);
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
