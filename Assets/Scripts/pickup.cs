using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class pickup : MonoBehaviour
{
    private Transform theDest;
    private Transform player;
    private bool isHolding;
    private GameObject Pickup;


    void Awake()
    {
        isHolding = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        theDest = GameObject.FindGameObjectWithTag("Destination").transform;
        Pickup = GameObject.FindGameObjectWithTag("PickUp");
        Pickup.GetComponent<Image>().enabled = true;
    }
    private void Update()
    {
        if (isHolding)
        {
            Pickup.GetComponent<Image>().enabled = false;
            this.GetComponent<Rigidbody2D>().simulated = false;
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        //FOR UI!! OMG...
        if (((player.GetChild(2).position.x - this.transform.position.x) < 1.5 && (player.GetChild(2).position.y - this.transform.position.y) < 1) && !isHolding)
        {
            Pickup.GetComponent<Image>().enabled = true;
        }
        else if ((player.GetChild(2).position.x - this.transform.position.x) > 1.5)
        {
            Pickup.GetComponent<Image>().enabled = false;
        }
        if ((this.transform.position.x - player.GetChild(2).position.x) > 3)
        {
            Pickup.GetComponent<Image>().enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.tag == "Food")
        {
            //Enable Ui (To Eat the food, Press [F])
        }
    }
    void OnMouseDown()
    {
        if (((player.GetChild(2).position.x - this.transform.position.x) < 1.5 && (player.GetChild(2).position.y - this.transform.position.y) < 1))
        {
            isHolding = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            this.gameObject.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("Destination").transform;
        }
    }
    void OnMouseUp()
    {
        isHolding = false;
        this.transform.parent = null;
        GetComponent<Rigidbody2D>().gravityScale = 3;
        this.GetComponent<Rigidbody2D>().simulated = true;
    }

}
