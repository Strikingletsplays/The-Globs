using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 4;
    public int Health;
    private Vector3 ScaleChangeSize;
    //Spawn Baby
    public GameObject baby;
    private Image NewBaby;
    private Transform SpawnBaby; //Position to spawn
    private GlobPickupUI AllBabys; // Ui to pickup glob
    //UI --- Flip canvas for "PressFtoEat" && (oops..) && HealthBar
    private Canvas Canvas;
    public HealthBar healthbar;
    //Sound
    public AudioSource Hurt;
    public AudioSource HealthUp;
    public AudioSource BabyGlobCreate;
    public AudioSource NomNomNom;

    //Shake
    public float DamageShakeDuration = 0.3f;
    public float DamageShakeAmplitude = 1.2f;
    private float DamageShakeElapsedTime = 0f;

    //glow
    private PlayerGlow Glow;
    bool DD_running = false;
    bool inDarckness = false;
    //glow ui
    public Image GlobsNeedGlow;
    public Image GlobsDontNeedGlow;
    public Image EnableGlow;

    //Eating Particles
    public GameObject EatingParticles;

    //Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    void Start()
    {
        Glow = GameObject.FindGameObjectWithTag("GlowBar").GetComponent<PlayerGlow>();
        Canvas = gameObject.transform.Find("Canvas").GetComponent<Canvas>();
        AllBabys = GameObject.FindGameObjectWithTag("GameScripts").GetComponent<GlobPickupUI>();
        NewBaby = gameObject.transform.Find("Canvas").gameObject.transform.Find("NewBaby").GetComponent<Image>();
        Health = 2;
        healthbar.SetMaxHealth(MaxHealth);
        healthbar.SetHealth(Health);
        SpawnBaby = GameObject.FindGameObjectWithTag("Destination").transform;

        //shake
        if (VirtualCamera != null)
        {
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //flip canvas (for new baby)
        if (transform.rotation.y < 0)
        {
            Canvas.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        }
        else
        {
            Canvas.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 0, transform.eulerAngles.z);
        }
        if (Health <= 0) //if player dies
        {
            //enable death gui
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //fix health going over 4 
        if (Health > 4)
        {
            Health = 4;
        }
        //For shake (timer)
        if (DamageShakeElapsedTime > 0)
        {
            virtualCameraNoise.m_AmplitudeGain = DamageShakeAmplitude;
            DamageShakeElapsedTime -= Time.deltaTime;
        }
        else
        {
            virtualCameraNoise.m_AmplitudeGain = 0f;
            DamageShakeElapsedTime = 0f;
        }
        //UI for not glowing outside
        if (!Glow.PauseGlow && !inDarckness && !GlobsNeedGlow.enabled)
        {
            //ui (globs dont need to glow out side)
            GlobsDontNeedGlow.enabled = true;
        }
        else
        {
            GlobsDontNeedGlow.enabled = false;
        }
    }
    public void eatBaby()
    {
        NomNomNom.Play();
        Destroy(Instantiate(EatingParticles, transform.position, transform.rotation), 1f);
    }
    public void TakeDamage()
    {
        if (this.gameObject.GetComponent<Transform>().localScale.x > 0)
        {
            ScaleChangeSize = new Vector3(-0.3f, -0.3f, -0.3f);
            this.transform.localScale += ScaleChangeSize;
        }
        else
        {
            ScaleChangeSize = new Vector3(0.3f, -0.3f, -0.3f);
            this.transform.localScale += ScaleChangeSize;
        }
        Hurt.Play();
        Health -= 1;
        healthbar.SetHealth(Health);
        //Camera Shake
        DamageShakeElapsedTime = DamageShakeDuration;
    }
    public void increceHealth()
    {
        if (Health < 4)
        {
            HealthUp.Play();
            //increase scale when he is facing laft or right
            if (this.gameObject.GetComponent<Transform>().localScale.x > 0)
            {
                ScaleChangeSize = new Vector3(0.25f, 0.25f, 0.25f);
                this.transform.localScale += ScaleChangeSize;
            }
            else
            {
                ScaleChangeSize = new Vector3(-0.25f, 0.25f, 0.25f);
                this.transform.localScale += ScaleChangeSize;
            }
            Health++;
            healthbar.SetHealth(Health);
        }else if(Health == 4)
        {
            NewBaby.enabled = true;
            BabyGlobCreate.Play();
            GameObject NewBbay = Instantiate(baby, SpawnBaby.position, transform.rotation);
            AllBabys.Globs.Add(NewBbay);
            //wait for 2 second
            StartCoroutine(disableNewGlobUI(2f));
        }
    }
    private void OnTriggerStay2D(Collider2D collision)     //if in the cave and glow off --> take damage
    {
        if (collision.name == "CaveBackground" || collision.name == "LightColider")
        {
            inDarckness = true;
            if (Glow.PauseGlow)
            {
                //ui (I need light)
                GlobsNeedGlow.enabled = true;
                if(!(Glow.Slider.value == 0))
                    EnableGlow.enabled = true;
                //Take damage
                if (!DD_running)
                    StartCoroutine(DarknessDamage());
            }
            else
            {
                //if glow is enabled
                GlobsNeedGlow.enabled = false;
                EnableGlow.enabled = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "CaveBackground" || collision.name == "LightColider")
        {
            inDarckness = false;
            //Hide Ui
            StartCoroutine(HideUi());
        }
    }
    IEnumerator DarknessDamage()
    {
        DD_running = true;
        yield return new WaitForSeconds(2.5f);
        if (Glow.PauseGlow && inDarckness)
        {
            TakeDamage();
        }
        DD_running = false;
    }
    IEnumerator disableNewGlobUI(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NewBaby.enabled = false;
        yield return null;
    }
    IEnumerator HideUi()
    {
        yield return new WaitForSeconds(3);
        GlobsNeedGlow.enabled = false;
        EnableGlow.enabled = false;
        yield return null;
    }
}
