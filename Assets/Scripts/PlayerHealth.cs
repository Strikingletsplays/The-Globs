using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 4;
    public int Health;
    private Vector3 ScaleChangeSize;

    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
        {
            //enable death gui
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
            //increase scale
            if (this.gameObject.GetComponent<Transform>().localScale.x > 0)
            {
                ScaleChangeSize = new Vector3(0.3f, 0.3f, 0.3f);
                this.transform.localScale += ScaleChangeSize;
            }
            else
            {
                ScaleChangeSize = new Vector3(-0.3f, 0.3f, 0.3f);
                this.transform.localScale += ScaleChangeSize;
            }
            Health += 1;
            healthbar.SetHealth(Health);
        }
    }
}
