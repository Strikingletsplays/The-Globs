using System.Collections;
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
            Item.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (IPanel2.transform.childCount == 0)
        {
            Item = Instantiate(obj) as GameObject;
            Item.transform.parent = IPanel2.transform;
            Item.transform.position = IPanel2.transform.position;
            Item.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (IPanel3.transform.childCount == 0)
        {
            Item = Instantiate(obj) as GameObject;
            Item.transform.parent = IPanel3.transform;
            Item.transform.position = IPanel3.transform.position;
            Item.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (IPanel4.transform.childCount == 0)
        {
            Item = Instantiate(obj) as GameObject;
            Item.transform.parent = IPanel4.transform;
            Item.transform.position = IPanel4.transform.position;
            Item.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (IPanel5.transform.childCount == 0)
        {
            Item = Instantiate(obj) as GameObject;
            Item.transform.parent = IPanel5.transform;
            Item.transform.position = IPanel5.transform.position;
            Item.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    public void RemoveItem(string obj)
    {
        if (IPanel1.transform.childCount > 0 && IPanel1.transform.GetChild(0).tag == obj)
              Destroy(IPanel1.transform.GetChild(0).gameObject);
        else if (IPanel2.transform.childCount > 0 && IPanel2.transform.GetChild(0).tag == obj)
                Destroy(IPanel2.transform.GetChild(0).gameObject);
        else if (IPanel3.transform.childCount > 0 && IPanel3.transform.GetChild(0).tag == obj)
                Destroy(IPanel3.transform.GetChild(0).gameObject);
        else if (IPanel4.transform.childCount > 0 && IPanel4.transform.GetChild(0).tag == obj)
                Destroy(IPanel4.transform.GetChild(0).gameObject);
        else if (IPanel5.transform.childCount > 0 && IPanel5.transform.GetChild(0).tag == obj)
                Destroy(IPanel5.transform.GetChild(0).gameObject);
    }
}
