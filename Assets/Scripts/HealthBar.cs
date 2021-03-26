using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    Slider healthSlider;


    void Awake()
    {
        healthSlider = GetComponent<Slider>();
    }

    public void SetHealthValue(float value)
    {
        healthSlider.value = value;
    }

}

