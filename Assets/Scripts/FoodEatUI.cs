using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodEatUI : MonoBehaviour
{
    private Image PressFtoEat;
    private FoodPickupUi FoodPickupUi;
    private int CloseFood;
    // Start is called before the first frame update
    void Start()
    {
        FoodPickupUi = GameObject.FindGameObjectWithTag("GameScripts").GetComponent<FoodPickupUi>();
        PressFtoEat = GameObject.FindGameObjectWithTag("PressFtoEat").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i< FoodPickupUi.Food.Count; i++)
        {
            //when pickable object gets destroid
            if (FoodPickupUi.Food[i] == null)
            {
                CloseFood = -1;
                FoodPickupUi.Food.Remove(FoodPickupUi.Food[i]);
                PressFtoEat.enabled = false;
                continue;
            }
            if (FoodPickupUi.Food[i].GetComponent<pickup>().isHolding)
            {
                PressFtoEat.enabled = false;
            }
            //UI Pickup object
            if (FoodPickupUi.Food[i].GetComponent<pickup>().isClose && !FoodPickupUi.Food[i].GetComponent<pickup>().isHolding)
            {
                CloseFood = i;
                PressFtoEat.enabled = true;
            }
            else if (FoodPickupUi.Food[i].GetComponent<pickup>().isClose && FoodPickupUi.Food[i].GetComponent<pickup>().isHolding)
            {
                PressFtoEat.enabled = false;
            }
        }
        if (CloseFood != -1 && FoodPickupUi.Food[CloseFood] != null)
            if (!FoodPickupUi.Food[CloseFood].GetComponent<pickup>().isClose)
            {
                PressFtoEat.enabled = false;
            }
    }
}
