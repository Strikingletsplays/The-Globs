using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 4;
    public int CurentHealth;

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
        }
    }
    public void TakeDamage(int damage)
    {
        CurentHealth -= damage;
        healthbar.SetHealth(CurentHealth);
    }
}
