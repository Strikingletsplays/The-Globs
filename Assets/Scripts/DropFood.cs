using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFood : MonoBehaviour
{
    public GameObject food,food2,food3,food4;
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Enable Ui

        //Enables RB simulation
        if (Input.GetMouseButtonDown(0))
        {
            if(food.GetComponent<Rigidbody2D>().simulated == false)
            {
                food.GetComponent<pickup>().enabled = true;
                food.GetComponent<Rigidbody2D>().simulated = true;
            }else if (food2.GetComponent<Rigidbody2D>().simulated == false)
            {
                food2.GetComponent<pickup>().enabled = true;
                food2.GetComponent<Rigidbody2D>().simulated = true;
            }else if (food3.GetComponent<Rigidbody2D>().simulated == false)
            {
                food3.GetComponent<pickup>().enabled = true;
                food3.GetComponent<Rigidbody2D>().simulated = true;
            }
            else if (food4.GetComponent<Rigidbody2D>().simulated == false)
            {
                food4.GetComponent<pickup>().enabled = true;
                food4.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
    }
}
