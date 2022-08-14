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

    public GameObject Restart;

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
            saveOrbit();
            Debug.Log(planetName);
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
        float[] shipPosition = {transform.position.x, transform.position.y, transform.position.z};
        SaveData.shipPosition = shipPosition;
        float shipRotationZ =  transform.localEulerAngles.z;
        Debug.Log(transform.rotation);
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
        SceneManager.LoadScene("Earth", LoadSceneMode.Single);
        Restart.SetActive(false);
    }
}
