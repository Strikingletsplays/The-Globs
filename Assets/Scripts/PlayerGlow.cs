using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGlow : MonoBehaviour
{
    public Slider Slider;
    public Light2D Glow;

    private void Update()
    {
        if (Slider.value != 0)
        {
            Glow.pointLightInnerRadius -= 0.01f * Time.deltaTime;
            Slider.value -= 0.01f * Time.deltaTime;
            Glow.intensity -= 0.01f * Time.deltaTime;
        }
        if (Slider.value > 1)
        {
            Slider.value = 1;
            Glow.intensity = 1;
        }
        if (Slider.value < 0)
        {
            Slider.value = 0;
            Glow.intensity = 0.3f;
        }
    }
    public void IncreseGlow(int ammount)
    {
        Glow.pointLightInnerRadius += 0.1f * ammount;
        Glow.intensity += 0.1f * ammount;
        Slider.value += 0.1f * ammount;
    }
}
