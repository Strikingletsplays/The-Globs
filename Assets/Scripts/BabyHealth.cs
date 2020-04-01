using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;

public class BabyHealth : MonoBehaviour
{
    public int Health = 1;
    public int MaxHealth = 3;

    //Ui Elements
    public HealthBar HealthBar;
    public GameObject Hungry; 
    public GameObject Happy;

    //Sound
    public AudioSource Dead;
    public AudioSource Hurt;
    public AudioSource HealthUp;

    //Glow anim
    public Light2D Glow;

    private void Start()
    {
        HealthBar.SetMaxHealth(MaxHealth);
        HealthBar.SetHealth(Health);
        Hungry.GetComponent<SpriteRenderer>().enabled = true;
        Happy.GetComponent<SpriteRenderer>().enabled = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if(Health >= MaxHealth)
        {
            //enable happy UI
            Happy.GetComponent<SpriteRenderer>().enabled = true;
            HealthBar.enabled = false;
            Hungry.GetComponent<SpriteRenderer>().enabled = false;
            Health = MaxHealth;
            Glow.intensity = 0.4f;
        }
        else
        {
            //enable hungry UI
            Happy.GetComponent<SpriteRenderer>().enabled = false;
            HealthBar.enabled = true;
            Hungry.GetComponent<SpriteRenderer>().enabled = true;
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
        //GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        Destroy(gameObject,0.4f);
    }
}
