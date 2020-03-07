using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIpickup : MonoBehaviour
{
    private GameObject Player;
    private Image Pickup;
    private GameObject[] pickupScripts;
    public int CloseObj;
    // Start is called before the first frame update
    void Start()
    {
        pickupScripts = GameObject.FindGameObjectsWithTag("Food");
        Pickup = GameObject.FindGameObjectWithTag("PickUp").GetComponent<Image>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pickupScripts.Length; i++) {
            //when pickable object gets destroid
            if (pickupScripts[i] == null) continue;

            if (pickupScripts[i].GetComponent<pickup>().isHolding)
            {
                Pickup.enabled = false;
            }
            //UI Pickup object
            if (pickupScripts[i].GetComponent<pickup>().isClose && !pickupScripts[i].GetComponent<pickup>().isHolding)
            {
                CloseObj = i;
                Pickup.enabled = true;
            }
            else if (pickupScripts[i].GetComponent<pickup>().isClose && pickupScripts[i].GetComponent<pickup>().isHolding)
            {
                Pickup.enabled = false;
            }
        }
        if (pickupScripts[CloseObj] != null)
            if (!pickupScripts[CloseObj].GetComponent<pickup>().isClose)
            {
                Pickup.enabled = false;
            }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.tag == "Food")
        {
            //Enable Ui (To Eat the food, Press [F])
        }
    }
}
