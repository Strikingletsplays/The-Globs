using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFood : MonoBehaviour
{
    private int food_size;
    public GameObject[] foods;
    bool isTime = true;
    private void Start()
    {
        food_size = foods.Length;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Enable Ui (Click on tree for food!!)

        //Enables RB simulation
        if (Input.GetMouseButtonDown(0) && isTime)
        {
            isTime = false;
            for (int i = 0; i<food_size; i++)
            {
                if(foods[i])
                    if (!(foods[i].GetComponent<Rigidbody2D>().simulated))
                    {
                        foods[i].GetComponent<pickup>().enabled = true;
                        foods[i].GetComponent<Rigidbody2D>().simulated = true;
                        break;
                    }
            }
            //So double clicks dont drop 2
            Invoke("setTimer", 0.6f);
        }
    }
    void setTimer()
    {
        isTime = true;
    }
}
