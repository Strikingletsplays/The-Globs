using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyHealth : MonoBehaviour
{
    public int Health = 1;
    private Vector3 ScaleChangeSize;

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            //kill baby
            Destroy(this.gameObject);
        }
        if(Health > 4)
        {
            Health = 4;
        }
    }
    public void increceHealth()
    {
        if(Health <= 4) {
            Health++;
            //increase scale
            if(this.gameObject.GetComponent<Transform>().localScale.x > 0) {
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
            //decrese scale
            if (this.gameObject.GetComponent<Transform>().localScale.x > 0)
            {
                ScaleChangeSize = new Vector3(-0.1f, -0.1f, -0.1f);
                this.transform.localScale += ScaleChangeSize;
            }
            else
            {
                ScaleChangeSize = new Vector3(0.1f, -0.1f, -0.1f);
                this.transform.localScale += ScaleChangeSize;
            }
    }
}
