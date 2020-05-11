using UnityEngine;
using UnityEngine.UI;

public class keys : MonoBehaviour
{
    public GameObject keysGO;
    private Inventory Inventory;
    private void Start()
    {
        Inventory = GameObject.FindGameObjectWithTag("InventoryPanel").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //InventoryUI
            Inventory.addItem(keysGO);
            Destroy(this.gameObject);
        }
    }
}
