using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    void Update(){
        GameObject fuelBarFill = GameObject.FindWithTag("FuelBarFill");
        Bar_controller fuel_bar_controller = fuelBarFill.GetComponent<Bar_controller>();
        fuel_bar_controller.setFillRate(SaveData.fuel);
        GameObject healthBarFill = GameObject.FindWithTag("HealthBarFill");
        Bar_controller health_bar_controller = healthBarFill.GetComponent<Bar_controller>();
        health_bar_controller.setFillRate(SaveData.health);
        GameObject goldText = GameObject.FindWithTag("GoldText");
        TextMeshProUGUI text = goldText.GetComponent<TextMeshProUGUI>();
        text.text = SaveData.coin.ToString();
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Coin"){
            SaveLoad.Load();
            SaveData.coin++;
            GameObject goldText = GameObject.FindWithTag("GoldText");
            TextMeshProUGUI text = goldText.GetComponent<TextMeshProUGUI>();
            text.text = SaveData.coin.ToString();
            col.gameObject.SetActive(false);
            SaveLoad.Save();
        }
        else if(col.tag == "Fuel"){
            SaveLoad.Load();
            if(SaveData.fuel < 1.0f){
                SaveData.fuel += 0.1f;
                GameObject fillBar = GameObject.FindWithTag("FuelBarFill");
                Bar_controller bar_controller = fillBar.GetComponent<Bar_controller>();
                bar_controller.setFillRate(SaveData.fuel);
            }
            col.gameObject.SetActive(false);
            SaveLoad.Save();
        }
        else if(col.tag == "Food"){
            SaveLoad.Load();
            if(SaveData.health < 1.0f){
                SaveData.health += 0.1f;
                GameObject fillBar = GameObject.FindWithTag("HealthBarFill");
                Bar_controller bar_controller = fillBar.GetComponent<Bar_controller>();
                bar_controller.setFillRate(SaveData.health);
            }
            col.gameObject.SetActive(false);
            SaveLoad.Save();
        }
        else if(col.tag == "Meteor"){
            SaveLoad.Load();
            if(SaveData.health < 1.0f){
                SaveData.health -= 0.1f;
                GameObject fillBar = GameObject.FindWithTag("HealthBarFill");
                Bar_controller bar_controller = fillBar.GetComponent<Bar_controller>();
                bar_controller.setFillRate(SaveData.health);
            }
            SaveLoad.Save();
        }
    }
}
