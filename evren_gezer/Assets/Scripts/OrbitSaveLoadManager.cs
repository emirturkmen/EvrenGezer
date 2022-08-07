using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitSaveLoadManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GameObject ship = GameObject.FindWithTag("ship");
            OrbitSaveData.fuel = PlayerStats.fuel;
            OrbitSaveData.health = PlayerStats.health;
            OrbitSaveData.coin = PlayerStats.coin;
            float[] shipPos = {ship.transform.position.x, ship.transform.position.y, ship.transform.position.z};
            OrbitSaveData.shipRot = shipPos;
            float[] shipRot = {ship.transform.rotation.x, ship.transform.rotation.y, ship.transform.rotation.z};
            OrbitSaveData.shipRot = shipRot;
           //OrbitSaveData.shipVelo = ship.transform.position.z;
            OrbitSaveLoad.Save();
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            OrbitSaveLoad.Load();
            PlayerStats.fuel = OrbitSaveData.fuel;
            PlayerStats.health = OrbitSaveData.health;
            PlayerStats.coin = OrbitSaveData.coin;
            float[] shipPos = OrbitSaveData.shipPos;
            float[] shipRot = OrbitSaveData.shipRot;
            // velo kismi
        }

        
    }
}
