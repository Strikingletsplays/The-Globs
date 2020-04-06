using UnityEngine;
using UnityEngine.UI;

public class keys : MonoBehaviour
{
    public Image keysUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //get key
            keysUI.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
