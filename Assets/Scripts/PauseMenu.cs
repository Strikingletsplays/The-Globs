using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour 
{
    public float MainVolumeTemp;

    public AudioMixer mixer;
    public AudioMixer Effects;
    public static bool GameIsPaused = false;
    public bool Options = false;
    public GameObject Camera;
    public GameObject PauseMenuUI;
    public GameObject OptionsMenuUI;
    public Light2D GlobalLight;
    private void Start()
    {
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused && !Options)
            {
                Resume();
            }else if(GameIsPaused && Options)
            {
                //close options
                OptionsMenuUI.SetActive(false);
                Options = false;
                //go back to pause screen
                Pause();
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
        Cursor.visible = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
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
