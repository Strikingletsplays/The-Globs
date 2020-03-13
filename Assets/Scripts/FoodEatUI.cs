using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodEatUI : MonoBehaviour
{
    private Image PressFtoEat;
    private FoodPickupUi FoodPickupUi;
    // Start is called before the first frame update
    void Start()
    {
        FoodPickupUi = GameObject.FindGameObjectWithTag("GameScripts").GetComponent<FoodPickupUi>();
        PressFtoEat = GameObject.FindGameObjectWithTag("PressFtoEat").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i< FoodPickupUi.Food.Count; i++)
        {
            //when pickable object gets destroid
            if (FoodPickupUi.Food[i] == null)
            {
                PressFtoEat.enabled = false;
                continue;
            }
            //UI Pickup object
            if (FoodPickupUi.Food[i].GetComponent<pickup>().isClose && !FoodPickupUi.Food[i].GetComponent<pickup>().isHolding)
            {
                PressFtoEat.enabled = true;
            }
            else if (FoodPickupUi.Food[i].GetComponent<pickup>().isClose && FoodPickupUi.Food[i].GetComponent<pickup>().isHolding)
            {
                PressFtoEat.enabled = false;
            }
        }
        //Disable UI if nothing if food is destroyed 
        if (FoodPickupUi.CloseFood != -1)
        {
            if (!FoodPickupUi.Food[FoodPickupUi.CloseFood].GetComponent<pickup>().isClose)
            {
                PressFtoEat.enabled = false;
            }
        }else PressFtoEat.enabled = false;
    }
}
