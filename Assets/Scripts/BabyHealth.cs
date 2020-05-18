using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BabyHealth : MonoBehaviour
{
    public int Health = 1;
    public int MaxHealth = 3;

    //Ui Elements
    public HealthBar HealthBar;
    public Image Hungry; 
    public Image Happy;
    public Image noView;

    //Sound
    public AudioSource Dead;
    public AudioSource Hurt;
    public AudioSource HealthUp;

    //Glow anim
    public Light2D Glow;
    bool inDarckness = false;
    private Image GlobsNeedGlow;

    //Particle System Damage
    public ParticleSystem DamagePS;

    private void Start()
    {
        GlobsNeedGlow = GameObject.FindGameObjectWithTag("GlobsNeedGlow").GetComponent<Image>();
        HealthBar.SetMaxHealth(MaxHealth);
        HealthBar.SetHealth(Health);
        Hungry.enabled = true;
        Happy.enabled = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if(Health >= MaxHealth)
        {
            //enable happy UI
            Happy.enabled = true;
            Hungry.enabled = false;
            HealthBar.enabled = false;
            Health = MaxHealth;
            Glow.intensity = 0.4f;
        }
        else
        {
            //enable hungry UI
            Happy.enabled = false;
            Hungry.enabled = true;
            HealthBar.enabled = true;
        }
    }
    public void increceHealth()
    {
        //Play sound
        HealthUp.Play();
        //glow intenity
        Glow.intensity += 0.1f;
        //Check if baby health is bellow 3
        if (Health < 3) 
        {
            Health++;
            HealthBar.SetHealth(Health);
            //Check if baby is facing left or right to scale properly
            if (transform.localScale.x > 0)
            {
                //increase scale
                transform.localScale += new Vector3(0.1f, 0.1f, 0);
            }
            else
            {
                transform.localScale += new Vector3(-0.1f, 0.1f, 0);
            }
        }
    }
    public void TakeDamage()
    {
        DamagePS.Play();
        Health--;
        HealthBar.SetHealth(Health);
        //Play sound
        Hurt.Play();
        //Glow Intencity
        Glow.intensity -= 0.1f;
        //decrese scale
        if (Health > 0)
        {
            //Check if baby is facing left or right to scale properly
            if (transform.localScale.x > 0)
            {
                //increase scale
                transform.localScale += new Vector3(-0.1f, -0.1f, 0);
            }
            else
            {
                transform.localScale += new Vector3(0.1f, -0.1f, 0);
            }
        }
        else if (Health <= 0)
        {
            isdead();
        }
    }
    public void isdead()
    {
        //kill babyGlob
        Dead.Play();
        //disable Ui elements
        transform.Find("Canvas").gameObject.SetActive(false);
        //disable player sprite
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        Destroy(gameObject,0.4f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "CaveBackground" || collision.name == "LightColider")
        {
            GlobsNeedGlow.GetComponent<Image>().enabled = true;
            inDarckness = true;
            StartCoroutine(DarknessDamage());
        }else
        {
            //ui (I need light)
            GlobsNeedGlow.GetComponent<Image>().enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "CaveBackground" || collision.name == "LightColider")
        {
            inDarckness = false;
            //ui (I need light)
            GlobsNeedGlow.enabled = false;
        }
    }
    IEnumerator DarknessDamage()
    {
        yield return new WaitForSeconds(2);
        if (Health==1 && inDarckness)
        {
            TakeDamage();
        }
    }
}
