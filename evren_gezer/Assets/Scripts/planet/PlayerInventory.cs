using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public static float coin = 0f;
    public static float fuel = 0.5f;
    public static float health = 0.5f;

    void Update(){
        GameObject fuelBarFill = GameObject.FindWithTag("FuelBarFill");
        Bar_controller fuel_bar_controller = fuelBarFill.GetComponent<Bar_controller>();
        fuel_bar_controller.setFillRate(fuel);
        GameObject healthBarFill = GameObject.FindWithTag("HealthBarFill");
        Bar_controller health_bar_controller = healthBarFill.GetComponent<Bar_controller>();
        health_bar_controller.setFillRate(health);
        GameObject goldText = GameObject.FindWithTag("GoldText");
        TextMeshProUGUI text = goldText.GetComponent<TextMeshProUGUI>();
        text.text = coin.ToString();
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Coin"){
            coin++;
            GameObject goldText = GameObject.FindWithTag("GoldText");
            TextMeshProUGUI text = goldText.GetComponent<TextMeshProUGUI>();
            text.text = coin.ToString();
            col.gameObject.SetActive(false);
        }
        else if(col.tag == "Fuel"){
            if(fuel < 1.0f){
                fuel += 0.1f;
                GameObject fillBar = GameObject.FindWithTag("FuelBarFill");
                Bar_controller bar_controller = fillBar.GetComponent<Bar_controller>();
                bar_controller.setFillRate(fuel);
            }
            col.gameObject.SetActive(false);
        }
        else if(col.tag == "Food"){
            if(health < 1.0f){
                health += 0.1f;
                GameObject fillBar = GameObject.FindWithTag("HealthBarFill");
                Bar_controller bar_controller = fillBar.GetComponent<Bar_controller>();
                bar_controller.setFillRate(health);
            }
            col.gameObject.SetActive(false);
        }
        else if(col.tag == "Trap"){
            if(health > 0f){
                health -= 0.1f;
                GameObject fillBar = GameObject.FindWithTag("HealthBarFill");
                Bar_controller bar_controller = fillBar.GetComponent<Bar_controller>();
                bar_controller.setFillRate(health);
            }
            col.gameObject.SetActive(false);
        }
    }

    
}
