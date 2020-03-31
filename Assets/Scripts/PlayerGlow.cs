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
        //intensity
        if (Glow.intensity > 0)
            Glow.intensity -= 0.01f * Time.deltaTime;
        else if (Glow.intensity > 2)
            Glow.intensity = 2;
        else if (Glow.intensity < 0)
            Glow.intensity = 0f;

        //slider value
        if (Slider.value > 0)
            Slider.value -= 0.01f * Time.deltaTime;
        else if (Slider.value > 2)
            Slider.value = 2;
        else if (Slider.value < 0)
            Slider.value = 0;

        //glow inner radius
        if (Glow.pointLightInnerRadius > 0)
           Glow.pointLightInnerRadius -= 0.01f * Time.deltaTime;
        else if (Glow.pointLightInnerRadius > 2)
            Glow.pointLightInnerRadius = 2;
        else if (Glow.pointLightInnerRadius < 0)
            Glow.pointLightInnerRadius = 0;

    }
    public void IncreseGlow(int ammount)
    {
        Glow.pointLightInnerRadius += 0.1f * ammount;
        Glow.intensity += 0.15f * ammount;
        Slider.value += 0.2f * ammount;
    }
}
