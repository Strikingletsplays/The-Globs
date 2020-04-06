using UnityEngine;
using UnityEngine.UI;

public class UnlockUnderground : MonoBehaviour
{
    public Image keys;
    public Image PressFtoUnlock;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(keys.enabled == true)
            {
                //show image (Press [f] to unlock door)
                PressFtoUnlock.enabled = true;
                if (Input.GetKey(KeyCode.F))
                {
                    PressFtoUnlock.enabled = false;
                    keys.enabled = false;
                    Destroy(this.gameObject);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (keys.enabled == true)
            {
                PressFtoUnlock.enabled = false;
            }
        }
    }
}
