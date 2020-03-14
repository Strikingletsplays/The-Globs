using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyHealth : MonoBehaviour
{
    public Renderer rend;
    public int Health = 1;
    public int MaxHealth = 4;
    private Vector3 ScaleChangeSize;

    //Ui Elements
    public HealthBar HealthBar;
    public GameObject Hungry; 
    public GameObject Happy;

    //Sound
    
    public AudioSource Dead;
    public AudioSource Hurt;
    public AudioSource HealthUp;

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

        if(Health >= 4)
        {
            //enable happy UI
            Happy.GetComponent<SpriteRenderer>().enabled = true;
            HealthBar.enabled = false;
            Hungry.GetComponent<SpriteRenderer>().enabled = false;
            Health = 4;
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
        HealthUp.Play();
        if (Health <= 3) {
            Health++;
            HealthBar.SetHealth(Health);
            //increase scale
            if (gameObject.GetComponent<Transform>().localScale.x > 0) {
                ScaleChangeSize = new Vector3(0.1f, 0.1f, 0.1f);
                transform.localScale += ScaleChangeSize;
            }
            else {
                ScaleChangeSize = new Vector3(-0.1f, 0.1f, 0.1f);
                transform.localScale += ScaleChangeSize;
            }
        }
    }
    public void TakeDamage()
    {
        Health--;
        HealthBar.SetHealth(Health);
        Hurt.Play();
        //decrese scale
        if (gameObject.GetComponent<Transform>().localScale.x > 0)
         {
            ScaleChangeSize = new Vector3(-0.1f, -0.1f, -0.1f);
            transform.localScale += ScaleChangeSize;
        }else{
            ScaleChangeSize = new Vector3(0.1f, -0.1f, -0.1f);
            transform.localScale += ScaleChangeSize;
        }
        if (Health <= 0)
        {
            //kill b_Glob
            rend.enabled = false;
            Dead.Play();
            Destroy(gameObject,0.4f);
        }
    }
}
