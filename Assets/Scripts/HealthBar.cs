﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider Slider;
    // Start is called before the first frame update
    public void SetMaxHealth(int health)
    {
        Slider.maxValue = health;
        Slider.value = health;
    }
    public void SetHealth(int health)
    {
        Slider.value = health;
    }
}
