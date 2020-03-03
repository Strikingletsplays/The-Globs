using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
            if(collision.gameObject.name == "ParentGlob")
            {
                //Enable FOOD UI
                if (Input.GetKeyDown(KeyCode.F))
                {
                    collision.gameObject.GetComponent<PlayerHealth>().increceHealth();
                    Destroy(this.gameObject);
                }
            }else if (collision.gameObject.tag == "BabyGlob")
            {
                  collision.gameObject.GetComponent<BabyHealth>().increceHealth();
                  Destroy(this.gameObject);
            }
        }
}
