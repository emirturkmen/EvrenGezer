using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_controller : MonoBehaviour
{
    public float fill_rate = 0.5f;
    public bool Update_auto = true;
    public Image FillImage;

    public void UpdateBar()
    {
        FillImage.fillAmount = fill_rate;
    }

    public void ReduceBar(float reduceAmount)
    {
        FillImage.fillAmount -= reduceAmount;
    }

    public void setFillRate(float f)
    {
       fill_rate = f;
       UpdateBar();
    }

    private void Update()
    {
        if (Update_auto)
            UpdateBar();
    }

}
