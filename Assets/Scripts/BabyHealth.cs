using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BabyHealth : MonoBehaviour
{
    public int Health = 1;
    public int MaxHealth = 4;
    private Vector3 ScaleChangeSize;

    //Ui Elements
    public HealthBar HealthBar;
    public GameObject Hungry; 
    public GameObject HungryGlobal;
    public GameObject Happy;
    public GameObject Horrible;

    private void Start()
    {
        HealthBar.SetMaxHealth(MaxHealth);
        Hungry.GetComponent<SpriteRenderer>().enabled = false;
        Happy.GetComponent<SpriteRenderer>().enabled = false;
        Horrible.GetComponent<Image>().enabled = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HealthBar.SetHealth(Health);
        if (Health <= 0)
        {
            //kill b_Glob
            Destroy(this.gameObject);
            HungryGlobal.GetComponent<Image>().enabled = false;
            Hungry.GetComponent<SpriteRenderer>().enabled = false;
            Horrible.GetComponent<Image>().enabled = true;
            //Enable :((( UI
        }
        if(Health >= 4)
        {
            //enable happy UI
            Happy.GetComponent<SpriteRenderer>().enabled = true;
            HealthBar.enabled = false;
            Hungry.GetComponent<SpriteRenderer>().enabled = false;
            HungryGlobal.GetComponent<Image>().enabled = false;
            Health = 4;
        }
        else
        {
            //enable hungry UI
            Happy.GetComponent<SpriteRenderer>().enabled = false;
            HealthBar.enabled = true;
            HungryGlobal.GetComponent<Image>().enabled = true;
            Hungry.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public void increceHealth()
    {
        if(Health <= 3) {
            Health++;
            HealthBar.SetHealth(Health);
            //increase scale
            if (this.gameObject.GetComponent<Transform>().localScale.x > 0) {
                ScaleChangeSize = new Vector3(0.1f, 0.1f, 0.1f);
                this.transform.localScale += ScaleChangeSize;
            }
            else {
                ScaleChangeSize = new Vector3(-0.1f, 0.1f, 0.1f);
                this.transform.localScale += ScaleChangeSize;
            }
        }
    }
    public void TakeDamage()
    {
        Health--;
        HealthBar.SetHealth(Health);
        //decrese scale
        if (this.gameObject.GetComponent<Transform>().localScale.x > 0)
         {
            ScaleChangeSize = new Vector3(-0.1f, -0.1f, -0.1f);
            this.transform.localScale += ScaleChangeSize;
        }else{
            ScaleChangeSize = new Vector3(0.1f, -0.1f, -0.1f);
            this.transform.localScale += ScaleChangeSize;
        }
    }
}
