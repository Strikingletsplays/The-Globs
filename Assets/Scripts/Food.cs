using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    private Image Pickup;
    bool inTrigger = false;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Pickup = GameObject.FindGameObjectWithTag("PickUp").GetComponent<Image>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ParentGlob")
        {
            inTrigger = true;
        }
        if (collision.gameObject.tag == "BabyGlob")
        {
            collision.gameObject.GetComponent<BabyHealth>().increceHealth();
            Pickup.enabled = false;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ParentGlob")
        {
            inTrigger = false;
        }
    }
    private void Update()
    {
        //Enable FOOD UI
        if (Input.GetKeyDown(KeyCode.F) && inTrigger)
        {
            Player.GetComponent<PlayerHealth>().increceHealth();
            Pickup.enabled = false; //NOT WORKING!!
            Destroy(this.gameObject);
        }
        
    }
}
