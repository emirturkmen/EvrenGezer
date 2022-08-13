using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class orbitcontroller : MonoBehaviour
{
    public GameObject[] planets;
    public GameObject Rocket;
    public GameObject planetEnterText;
    public GameObject Escape;

    public GameObject Restart;

    private void Update()
    {
        string planetName = "";
        foreach (GameObject item in planets){
            if(Vector2.Distance(item.transform.position,Rocket.transform.position) < 6)
            {
                planetName = item.name;                
            }
        }

        if (!planetName.Equals(""))
        {
            planetEnterText.GetComponent<TMPro.TextMeshProUGUI>().text = "Press 'E' to enter the \n" + planetName;
        }
        else
        {
            planetEnterText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }

        if (Input.GetKeyDown(KeyCode.E) && !planetName.Equals(""))
        {
            SceneManager.LoadScene(planetName, LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Escape.activeSelf)
            {
                Time.timeScale = 1;
                Escape.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                Escape.SetActive(true);
            }
        }
    }


    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void loadStore()
    {
        SceneManager.LoadScene("Store", LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void openRestart()
    {

    }
}
