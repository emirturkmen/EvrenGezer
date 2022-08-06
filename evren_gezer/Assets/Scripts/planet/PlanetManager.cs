using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetManager : MonoBehaviour
{
    public Transform player;
    public Transform rocket;

    public GameObject orbitText;


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
    }

    private void loadOrbit()
    {
        SceneManager.LoadScene("Orbit", LoadSceneMode.Single);

    }
}
