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
    public Image NewBaby;
    private Transform SpawnBaby; //Position to spawn
    public GlobPickupUI AllBabys; // Ui to pickup glob
    //UI --- Flip canvas for "PressFtoEat" && (oops..) && HealthBar
    public Canvas Canvas;
    public HealthBar healthbar;
    //Sound
    public AudioSource Hurt;
    public AudioSource HealthUp;
    public AudioSource BabyGlobCreate;

    //Shake
    public float ShakeDuration = 0.3f;
    public float ShakeAmplitude = 1.2f;
    private float ShakeElapsedTime = 0f;

    //glow
    public PlayerGlow Glow;
    bool DD_running = false;
    bool inDarckness = false;
    //glow ui
    public Image GlobsNeedGlow;

    //Cinemachine Shake
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    void Start()
    {
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
        if (Health <= 0)
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
        if (ShakeElapsedTime > 0)
        {
            virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
            ShakeElapsedTime -= Time.deltaTime;
        }
        else
        {
            virtualCameraNoise.m_AmplitudeGain = 0f;
            ShakeElapsedTime = 0f;
        }
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
        ShakeElapsedTime = ShakeDuration;
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
    //if in the cave and glow off --> take damage
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "CaveBackground" || collision.name == "LightColider")
        {
            inDarckness = true;
            if (Glow.PauseGlow)
            {
                //ui (I need light)
                GlobsNeedGlow.GetComponent<Image>().enabled = true;
                //Take damage
                if (!DD_running)
                    StartCoroutine(DarknessDamage());
            }
            else
            {
                //ui (I need light)
                GlobsNeedGlow.GetComponent<Image>().enabled = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "CaveBackground" || collision.name == "LightColider")
        {
            inDarckness = false;
            //ui (I need light)
            GlobsNeedGlow.GetComponent<Image>().enabled = false;
        }
    }
    IEnumerator DarknessDamage()
    {
        DD_running = true;
        yield return new WaitForSeconds(2);
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
}
