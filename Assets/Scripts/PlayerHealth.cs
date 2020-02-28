using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 4;
    public int CurentHealth;
    private Vector3 ScaleChangeSize;

    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        CurentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(CurentHealth <= 0)
        {
            //enable death gui
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (CurentHealth > 4)
        {
            CurentHealth = 4;
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
        CurentHealth -= 1;
        healthbar.SetHealth(CurentHealth);
    }
    public void increceHealth()
    {
        if (CurentHealth <= 4)
        {
            CurentHealth++;
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
            CurentHealth += 1;
            healthbar.SetHealth(CurentHealth);
        }
    }
}
