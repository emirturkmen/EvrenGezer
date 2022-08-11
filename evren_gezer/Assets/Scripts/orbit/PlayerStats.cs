using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float coin = 0f;
    public static float fuel = 0.5f;
    public static float health = 0.5f;
    

    public void setHealth(float h){
        health = h;
    }

    public void setFuel(float f){
        fuel = f;
    }

    public void setCoin(float c){
        coin = c;
    }
}
