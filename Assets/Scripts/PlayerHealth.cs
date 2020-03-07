using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 4;
    public int Health;
    private Vector3 ScaleChangeSize;
    public GameObject baby;

    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        Health = 2;
        healthbar.SetMaxHealth(MaxHealth);
        healthbar.SetHealth(Health);
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            //enable death gui
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //fix health going over 4 
        if (Health > 4)
        {
            Health = 4;
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
        Health -= 1;
        healthbar.SetHealth(Health);
    }
    public void increceHealth()
    {
        if (Health < 4)
        {
            Health++;
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
            Health += 1;
            healthbar.SetHealth(Health);
        }else if(Health == 4)
        {
            Instantiate(baby, transform.position, transform.rotation);
        }
    }
}
