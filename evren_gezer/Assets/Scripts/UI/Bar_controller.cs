using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar_controller : MonoBehaviour
{
    public float fill_rate = 0.5f;
    public bool Update_auto = false;
    public Image FillImage;

    public void UpdateBar()
    {
        FillImage.fillAmount = fill_rate;   
    }

    private void Update()
    {
        if (Update_auto)
            UpdateBar();
    }

}
