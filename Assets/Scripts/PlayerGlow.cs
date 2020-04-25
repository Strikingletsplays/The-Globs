using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGlow : MonoBehaviour
{
    public Slider Slider;
    public Light2D Glow;
    public bool PauseGlow = true;

    private void Start()
    {
        PauseGlowing();
    }

    private void Update()
    {
        if(Slider.value != 0 && Input.GetKeyDown(KeyCode.G))
        {
            if (!PauseGlow)
                PauseGlowing();
            else
            {
                ResumeGlow();
            }
        }

        //intensity
        if (Glow.intensity > 0 && !PauseGlow)
            Glow.intensity -= 0.01f * Time.deltaTime;
        else if (Glow.intensity > 1)
            Glow.intensity = 1;
        else if (Glow.intensity < 0)
        {
            PauseGlowing();
            Glow.intensity = 0f;
        }

        //slider value
        if (Slider.value > 0 && !PauseGlow)
            Slider.value -= 0.01f * Time.deltaTime;
        else if (Slider.value > 1)
            Slider.value = 1;

    }
    public void PauseGlowing()
    {
        PauseGlow = true;
        Glow.enabled = false;
    }
    public void ResumeGlow()
    {
        Glow.enabled = true;
        PauseGlow = false;
    }
    public void IncreseGlow(int ammount)
    {
        Glow.intensity += 0.166f * ammount;
        Slider.value += 0.166f * ammount;
    }
}
