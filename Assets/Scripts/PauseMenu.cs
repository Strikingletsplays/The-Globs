using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Experimental.Rendering.Universal;

public class PauseMenu : MonoBehaviour 
{
    public float MainVolumeTemp;

    public AudioMixer mixer;
    public AudioMixer Effects;
    public static bool GameIsPaused = false;
    public bool Options = false;
    public GameObject Camera;
    public GameObject PauseMenuUI;
    public Light2D GlobalLight;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused && !Options)
            {
                Resume();
            }
            else if (!Options)
            {
                Pause();
            }
        }
    }
    public void Brightness(float intensity)
    {
        GlobalLight.intensity = intensity;
    }
    public void OptionsIsUp()
    {
        Options = true;
    }
    public void OptionsIsDown()
    {
        Options = false;
    }
    public void Resume()
    {
        //Camera.GetComponent<AudioSource>().volume = 0.2f;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        //Camera.GetComponent<AudioSource>().volume = 0.05f;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        GameIsPaused = false;
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
