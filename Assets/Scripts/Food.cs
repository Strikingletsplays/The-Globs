﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    //Food UI elements
    private Image UIPressFtoEat;
    private Image UIPickUpFood;

    private PlayerHealth PlayerHealth;
    void Start()
    {
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        UIPickUpFood = GameObject.FindGameObjectWithTag("PickUp").GetComponent<Image>();
        UIPressFtoEat = GameObject.FindGameObjectWithTag("PressFtoEat").GetComponent<Image>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UIPickUpFood.enabled = true;
            UIPressFtoEat.enabled = true;
            if (Input.GetKey(KeyCode.F))
            {
                PlayerHealth.increceHealth();
                UIPickUpFood.enabled = false;
                UIPressFtoEat.enabled = false;
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BabyGlob")
        {
            collision.gameObject.GetComponent<BabyHealth>().increceHealth();
            UIPickUpFood.enabled = false;
            UIPressFtoEat.enabled = false;
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        UIPickUpFood.enabled = false;
        UIPressFtoEat.enabled = false;
    }
}
