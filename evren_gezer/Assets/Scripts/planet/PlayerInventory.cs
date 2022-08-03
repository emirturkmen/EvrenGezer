using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public int numberOfGold = 0;

    public void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Coin"){
            numberOfGold++;
            GameObject goldText = GameObject.FindWithTag("GoldText");
            TextMeshProUGUI text = goldText.GetComponent<TextMeshProUGUI>();
            text.text = numberOfGold.ToString();
        }
    }

    
}
