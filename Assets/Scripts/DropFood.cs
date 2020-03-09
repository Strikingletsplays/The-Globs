using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFood : MonoBehaviour
{
    private Transform Player;
    private int food_size;
    public GameObject[] foods;
    bool isTime = true;
    private float distance;
    private void Start()
    {
        food_size = foods.Length;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        distance = Vector3.Distance(transform.position, Player.position);
        if(distance < 2){
            //Enables RB simulation
            if (Input.GetMouseButtonDown(0) && isTime)
            {
                isTime = false;
                for (int i = 0; i < food_size; i++)
                {
                    if (foods[i])
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
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Enable Ui (Click on tree for food!!)
    }
    void setTimer()
    {
        isTime = true;
    }
}
