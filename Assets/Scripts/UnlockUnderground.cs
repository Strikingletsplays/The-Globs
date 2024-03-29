﻿using UnityEngine;
using UnityEngine.UI;

public class UnlockUnderground : MonoBehaviour
{
    private GameObject toDelete;
    public Image PressFtoUnlock;
    private Inventory Inventory;

    private void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("InventoryPanel").GetComponent<Inventory>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            toDelete = GameObject.FindGameObjectWithTag("KeysUI");
            if (toDelete)
            {
                //show image (Press [f] to unlock door)
                PressFtoUnlock.enabled = true;
                if (Input.GetKey(KeyCode.F))
                {
                    PressFtoUnlock.enabled = false;
                    Inventory.RemoveItem("KeysUI");
                    Destroy(this.gameObject);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PressFtoUnlock.enabled = false;
        }
    }
}
