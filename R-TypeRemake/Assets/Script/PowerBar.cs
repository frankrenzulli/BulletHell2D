using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar: MonoBehaviour
{

    public Slider PowerSlider;


    public void SetMaxPower ( int power)
    {
        PowerSlider.maxValue = power;
        PowerSlider.value = power;


    }    

    public void SetPower(int power)
    {
        PowerSlider.value = power;

    }    
 


}
