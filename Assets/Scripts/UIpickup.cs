using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIpickup : MonoBehaviour
{
    private Image Pickup;
    public List<GameObject> PickupObjects;
    public int CloseObj;

    //temp
    private GameObject BabyGlob;

    // Start is called before the first frame update
    void Start()
    {
        BabyGlob = GameObject.FindGameObjectWithTag("BabyGlob");
        PickupObjects = new List<GameObject> (GameObject.FindGameObjectsWithTag("Food"));
        PickupObjects.Add(GameObject.FindGameObjectWithTag("BabyGlob"));
        Pickup = GameObject.FindGameObjectWithTag("PickUp").GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        //Add baby glob clones to PickupObjects list (not working)
        //  if (!PickupObjects.Contains(BabyGlob) && BabyGlob != null)
        //      PickupObjects.Add(GameObject.FindGameObjectWithTag("BabyGlob"));

        for (int i = 0; i < PickupObjects.Count; i++) {

            //when pickable object gets destroid
            if (PickupObjects[i] == null) 
            {
                CloseObj = 0;
                PickupObjects.Remove(PickupObjects[i]);
                Pickup.enabled = false; 
                continue;
            }
            if (PickupObjects[i].GetComponent<pickup>().isHolding)
            {
                Pickup.enabled = false;
            }
            //UI Pickup object
            if (PickupObjects[i].GetComponent<pickup>().isClose && !PickupObjects[i].GetComponent<pickup>().isHolding)
            {
                CloseObj = i;
                Pickup.enabled = true;
            }
            else if (PickupObjects[i].GetComponent<pickup>().isClose && PickupObjects[i].GetComponent<pickup>().isHolding)
            {
                Pickup.enabled = false;
            }
        }
        if (PickupObjects[CloseObj] != null)
            if (!PickupObjects[CloseObj].GetComponent<pickup>().isClose)
            {
                Pickup.enabled = false;
            }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && tag == "Food")
        {
            //Enable Ui (To Eat the food, Press [F])
        }
    }
}
