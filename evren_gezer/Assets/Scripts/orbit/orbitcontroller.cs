using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class orbitcontroller : MonoBehaviour
{
    public GameObject[] planets;
    public GameObject Rocket;
    public GameObject planetEnterText;
    public GameObject Escape;
    public GameObject YouWin;

    public GameObject Restart;
    public GameObject gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController");
    }

    private void Update()
    {
        string planetName = "";
        if (Rocket != null)
        {
            foreach (GameObject item in planets)
            {
                if (Vector2.Distance(item.transform.position, Rocket.transform.position) < 8)
                {
                    planetName = item.name;
                }
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
            if (planetName.Equals("Venus"))
            {
                Time.timeScale = 0;
                YouWin.SetActive(true);
                return;
            }
            saveOrbit();
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
                SaveData.sceneName = SceneManager.GetActiveScene().name;
                SaveLoad.Save();
            }
        }
    }


    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void loadStore()
    {
        SceneManager.LoadScene("Store", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        Application.Quit();
    }


    private void saveOrbit(){
        float[] shipPosition = {Rocket.transform.position.x, Rocket.transform.position.y, Rocket.transform.position.z};
        SaveData.shipPosition = shipPosition;
        float shipRotationZ = Rocket.transform.localEulerAngles.z;
        SaveData.shipRotationZ = shipRotationZ;
        ship_controller shipScript = Rocket.GetComponent<ship_controller>();
        Image[] images = shipScript.images;
        int numberOfMissiles = 0;
        for(int i=0;i<images.Length;i++)
            if(images[i].isActiveAndEnabled)
                numberOfMissiles++;
        SaveData.numberOfMissiles = numberOfMissiles;
        SaveLoad.Save();
    }

    public void karakterOldu()
    {
        SaveLoad.LoadNewGame();
        Restart.SetActive(true);        
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        Restart.SetActive(false);
        SceneManager.LoadScene("Earth", LoadSceneMode.Single);
    }
}
