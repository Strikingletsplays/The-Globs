using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGun : MonoBehaviour
{
    private CharacterController2D controller;
    private bool isHoldingGun = false;
    private GameObject gun;
    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }
    private void Update()
    {
        //if player is holding gun and presses "F" he drops it
        if (isHoldingGun && Input.GetKey(KeyCode.F) && controller.m_Grounded)
        {
            StartCoroutine(DisableTrigger(2f));
            isHoldingGun = false;
        }
        if (isHoldingGun && Input.GetKeyDown("fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "water-gun")
        {
            isHoldingGun = true;
            gun = collision.gameObject;
            //set triger to false
            collision.GetComponent<PolygonCollider2D>().enabled = false;
            //make parent
            collision.transform.parent = GameObject.Find("Destination").transform;
            collision.transform.position += new Vector3(0f, 0.1f, 0f);
            //fix rotation of gun
            if (transform.position.x > gun.transform.position.x)
            {
                collision.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (transform.position.x < gun.transform.position.x)
            {
                collision.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            //Enable Ui (To-Do)
        }
    }
    //Need to fix
    IEnumerator DisableTrigger(float time)
    {
        //set parent to null
        gun.transform.parent = null;
        //make the gun go under players possition
        gun.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
        gun.transform.localScale = new Vector3(0.1716499f, 0.1716499f, 0.1716499f);
        gun.transform.rotation = Quaternion.Euler(33.223f, 29.443f, -27.444f);
        //WaitForSeconds for seconds
        yield return new WaitForSeconds(time);
        //set triger to enabled
        gun.GetComponent<PolygonCollider2D>().enabled = true;
        yield return null;
    }
}
