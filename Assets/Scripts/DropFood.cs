using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFood : MonoBehaviour
{
    public GameObject[] foods;
    bool isTime = true;
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Enable Ui (Click on tree for food!!)

        //Enables RB simulation
        if (Input.GetMouseButtonDown(0) && isTime)
        {
            isTime = false;
            if (foods[0] != null)
            {
                foods[0].GetComponent<pickup>().enabled = true;
                foods[0].GetComponent<Rigidbody2D>().simulated = true;
            }else if (foods[1] != null)
            {
                foods[1].GetComponent<pickup>().enabled = true;
                foods[1].GetComponent<Rigidbody2D>().simulated = true;
            }else if (foods[2] != null)
            {
                foods[2].GetComponent<pickup>().enabled = true;
                foods[2].GetComponent<Rigidbody2D>().simulated = true;
            }
            else if (foods[3] != null)
            {
                foods[3].GetComponent<pickup>().enabled = true;
                foods[3].GetComponent<Rigidbody2D>().simulated = true;
            }
            Invoke("setTimer", 0.4f);
        }
    }
    void setTimer()
    {
        isTime = true;
    }
}
