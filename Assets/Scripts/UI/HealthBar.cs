using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetHealth(int heath)
    {
        slider.value = heath;
    }

    public void SetHealth(float heath)
    {
        slider.value = heath;
    }

    public void SetMaxHealth(int heath)
    {
        slider.maxValue = heath;
        slider.value = heath;
    }

    public void SetMaxHealth(float heath)
    {
        slider.maxValue = heath;
        slider.value = heath;
    }
}
