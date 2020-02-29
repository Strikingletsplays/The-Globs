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
                    Destroy(this.gameObject.GetComponent<Renderer>());
                    Destroy(this.gameObject.GetComponent<CircleCollider2D>());
                    Destroy(this.gameObject.GetComponent<BoxCollider2D>());
                    collision.gameObject.GetComponent<PlayerHealth>().increceHealth();
                }
            }else if (collision.gameObject.tag == "BabyGlob")
            {
                Destroy(this.gameObject.GetComponent<Renderer>());
                Destroy(this.gameObject.GetComponent<CircleCollider2D>());
                Destroy(this.gameObject.GetComponent<BoxCollider2D>());
                collision.gameObject.GetComponent<BabyHealth>().increceHealth();
            }
        }
}
