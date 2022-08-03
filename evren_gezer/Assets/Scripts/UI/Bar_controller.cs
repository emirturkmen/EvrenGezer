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

    public void increaseFillRate()
    {
       if(fill_rate < 1.0f)
        fill_rate += 0.1f;
        UpdateBar();
    }

    public void decreaseFillRate()
    {
       if(fill_rate > 0f)
        fill_rate -= 0.1f;
        UpdateBar();
    }

    private void Update()
    {
        if (Update_auto)
            UpdateBar();
    }

}
