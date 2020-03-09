using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodPickupUi : MonoBehaviour
{
    public Image Pickup;
    public List<GameObject> Food;
    public int CloseFood;
    // Start is called before the first frame update
    void Start()
    {
        Food = new List<GameObject>(GameObject.FindGameObjectsWithTag("Food"));
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Food.Count; i++)
        {
            //when pickable object gets destroid
            if (Food[i] == null)
            {
                CloseFood = -1;
                Food.Remove(Food[i]);
                Pickup.enabled = false;
                continue;
            }
            if (Food[i].GetComponent<pickup>().isHolding)
            {
                Pickup.enabled = false;
            }
            //UI Pickup object
            if (Food[i].GetComponent<pickup>().isClose && !Food[i].GetComponent<pickup>().isHolding)
            {
                CloseFood = i;
                Pickup.enabled = true;
            }
            else if (Food[i].GetComponent<pickup>().isClose && Food[i].GetComponent<pickup>().isHolding)
            {
                Pickup.enabled = false;
            }
        }
        if (CloseFood != -1 && Food[CloseFood] != null)
            if (!Food[CloseFood].GetComponent<pickup>().isClose)
            {
                Pickup.enabled = false;
            }
    }
}
