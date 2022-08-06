using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{

    public string newGameScene;
    public string storeScene;

    public GameObject rocket;
    public float moveLatency;
    private Vector3 rocketTarget;

    
    public Button resume;        



    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (!checkResume())
        {
            resume.interactable = false;
        }

        rocketTarget = rocket.transform.position + rocket.transform.up.normalized * 5;
    }

    public void loadNewGame()
    {
        SceneManager.LoadScene(newGameScene, LoadSceneMode.Single);
    }


    //Emir burayi kayitlardan load edecek
    public bool checkResume()
    {
        return false;
    }

    public void loadStore()
    {
        SceneManager.LoadScene(storeScene, LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }


    private void Update()
    {
        if (moveLatency <= 0)
            rocket.transform.position = Vector3.Lerp(rocket.transform.position, rocketTarget, Time.deltaTime * 0.1f);
        else
            moveLatency -= Time.deltaTime;
    }

}
