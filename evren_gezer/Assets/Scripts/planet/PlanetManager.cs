using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetManager : MonoBehaviour
{
    public Transform player;
    public Transform rocket;

    public GameObject orbitText;
    public GameObject Escape;



    private void Update()
    {
        if(Vector3.Distance(player.position,rocket.position) > 2)
        {
            orbitText.gameObject.SetActive(false);
        }
        else
        {
            orbitText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                loadOrbit();
            }
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

    private void loadOrbit()
    {
        SceneManager.LoadScene("Orbit", LoadSceneMode.Single);
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
}
