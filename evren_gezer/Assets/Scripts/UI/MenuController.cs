using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class MenuController : MonoBehaviour
{

    public string newGameScene;
    public string storeScene;

    public GameObject rocket;
    public float moveLatency;
    private Vector3 rocketTarget;

    private bool isMainMenu = true;

    
    public Button resume;

    private AudioManager audiomanager;
    public GameObject gameManager;



    private void Start()
    {
        loadCoin();
        audiomanager = gameManager.GetComponent<AudioManager>();

        

        if (!checkResume())
        {
            resume.interactable = false;
        }

        rocketTarget = rocket.transform.position + rocket.transform.up.normalized * 5;

        audiomanager.playSound("background");
    }

    public void loadNewGame()
    {
        SaveLoad.LoadNewGame();
        SceneManager.LoadScene(newGameScene, LoadSceneMode.Single);
        audiomanager.playSound("button");
        isMainMenu = false;
        SaveLoad.Save();
    }


    //Emir burayi kayitlardan load edecek
    public bool checkResume()
    {
        audiomanager.playSound("button");
        if(File.Exists("GameSave.bin"))
            return true;
        return false;
    }

    public void loadSavedGame()
    {
        SceneManager.LoadScene(newGameScene, LoadSceneMode.Single);
        audiomanager.playSound("button");
        isMainMenu = false;
    }

    public void loadStore()
    {
        audiomanager.playSound("button");
        SceneManager.LoadScene(storeScene, LoadSceneMode.Single);
    }

    public void exitGame()
    {
        audiomanager.playSound("button");
        Application.Quit();
    }

    private void loadCoin()
    {
        SaveLoad.Load();
        Debug.Log(SaveData.health);
        Debug.Log(SaveData.fuel);
        GameObject goldText = GameObject.FindWithTag("GoldText");
        TextMeshProUGUI text = goldText.GetComponent<TextMeshProUGUI>();
        text.text = SaveData.coin.ToString();
    }


    private void Update()
    {
        if (isMainMenu) { 
            if (moveLatency <= 0)
                rocket.transform.position = Vector3.Lerp(rocket.transform.position, rocketTarget, Time.deltaTime * 0.1f);
            else
                moveLatency -= Time.deltaTime;
        }
    }

}
