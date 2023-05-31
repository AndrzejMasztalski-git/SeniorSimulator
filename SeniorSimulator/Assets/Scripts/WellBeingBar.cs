using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WellBeingBar : MonoBehaviour
{
    
    public Slider slider;

    public void SetMaxWellBeing(int wellBeing)
    {
        slider.maxValue = wellBeing;
        slider.value = wellBeing;
    }
    public void SetWellBeing(int wellBeing)
    {
        slider.value = wellBeing;
        
    }
}

