﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private GameObject IPanel1, IPanel2, IPanel3, IPanel4, IPanel5;
    private GameObject Item;

    public void addItem(GameObject obj)
    {
       if (IPanel1.transform.childCount == 0)
       {
            Item = Instantiate(obj) as GameObject;
            Item.transform.parent = IPanel1.transform;
            Item.transform.position = IPanel1.transform.position;
            Item.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        } else if (IPanel2.transform.childCount == 0)
        {
            Item = Instantiate(obj) as GameObject;
            Item.transform.parent = IPanel2.transform;
            Item.transform.position = IPanel2.transform.position;
            Item.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        else if (IPanel3.transform.childCount == 0)
        {
            Item = Instantiate(obj) as GameObject;
            Item.transform.parent = IPanel3.transform;
            Item.transform.position = IPanel3.transform.position;
            Item.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        else if (IPanel4.transform.childCount == 0)
        {
            Item = Instantiate(obj) as GameObject;
            Item.transform.parent = IPanel4.transform;
            Item.transform.position = IPanel4.transform.position;
            Item.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
        else if (IPanel5.transform.childCount == 0)
        {
            Item = Instantiate(obj) as GameObject;
            Item.transform.parent = IPanel5.transform;
            Item.transform.position = IPanel5.transform.position;
            Item.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        }
    }
}
