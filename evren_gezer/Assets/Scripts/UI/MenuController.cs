using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{

    public string newGameScene;
    public string storeScene;

    
    public Button resume;        



    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (!checkResume())
        {
            resume.interactable = false;
        }

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
}
