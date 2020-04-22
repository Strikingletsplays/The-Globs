using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Experimental.Rendering.Universal;

public class MainMenu : MonoBehaviour
{
    public Slider MusicVolume;
    private float MusicVolumeTemp;
    
    public GameObject OptionsMenu;
    public AudioMixer mixer;
    public AudioMixer Effects;
    /*
        private void Awake()
        {

            if (mixer.GetFloat("MusicVol", out MusicVolumeTemp))
            {
                //Need to fix :/
                //MusicVolume.value = Mathf.Log10(MusicVolumeTemp);
            }
        }*/
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SetLevel(float SliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(SliderValue) * 20);
    }
    public void SetEffectLevel(float SliderValue)
    {
        Effects.SetFloat("EffectVol", Mathf.Log10(SliderValue) * 20);
    }
}
