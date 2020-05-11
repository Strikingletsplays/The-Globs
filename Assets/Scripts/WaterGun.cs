using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    private CharacterController2D controller;
    public bool isHoldingGun = false;

    //For inventory UI
    private Inventory Inventory;
    public GameObject WaterGunGO;
    private void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("InventoryPanel").GetComponent<Inventory>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
    }
    private void Update()
    {
        //if player is holding gun and presses "X" he drops it
        if (isHoldingGun && Input.GetKey(KeyCode.X) && controller.m_Grounded)
        {
            StartCoroutine(DisableTrigger(2f));
            isHoldingGun = false;
            Inventory.RemoveItem("WaterGunUI");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //InventoryUI
            Inventory.addItem(WaterGunGO);

            isHoldingGun = true;
            //set triger to false
            GetComponent<PolygonCollider2D>().enabled = false;
            //fix guns (position-rotation) and position to Destinations
            transform.position += new Vector3(0f, 0.1f, 0f);
            //make parent
            transform.parent = GameObject.Find("Destination").transform;
            transform.position = GameObject.Find("Destination").transform.position;


            //fix rotation of gun
            if (controller.gameObject.transform.position.x > this.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (controller.gameObject.transform.position.x < this.transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            //Enable Ui (To-Do)
        }
    }
    IEnumerator DisableTrigger(float time)
    {
        //set parent to null
        transform.parent = null;
        //make the gun go under players possition
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        transform.rotation = Quaternion.Euler(0f, 0f, -36.562f);
        //WaitForSeconds for seconds
        yield return new WaitForSeconds(time);
        //set triger to enabled
        GetComponent<PolygonCollider2D>().enabled = true;
        yield return null;
    }
}
