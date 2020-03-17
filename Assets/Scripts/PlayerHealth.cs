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
    public GameObject baby;
    public Image NewBaby;
    //Spawn Baby
    private Transform SpawnBaby; //Position
    public GlobPickupUI AllBabys; // Add to list of globs
    //Flip canvas
    public Canvas Canvas;
    //Ui
    public HealthBar healthbar;
    //Sound
    public AudioSource Hurt;
    public AudioSource HealthUp;
    public AudioSource BabyGlobCreate;

    //Shake
    public float ShakeDuration = 0.3f;
    public float ShakeAmplitude = 1.2f;

    private float ShakeElapsedTime = 0f;

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
        //flip canvas
        if (transform.localScale.x < 0)
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
    IEnumerator disableNewGlobUI(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NewBaby.enabled = false;
        yield return null;
    }
}
