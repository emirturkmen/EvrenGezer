using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            SaveData.fuel = PlayerInventory.fuel;
            SaveData.health = PlayerInventory.health;
            SaveData.coin = PlayerInventory.coin;
            SaveLoad.Save();
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            SaveLoad.Load();
            PlayerInventory.fuel = SaveData.fuel;
            PlayerInventory.health = SaveData.health;
            PlayerInventory.coin = SaveData.coin;
        }

        
    }
}
