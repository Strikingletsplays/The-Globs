using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BabyGlob" && collision.gameObject.GetComponent<BabyHealth>().Health < 4)
        {
            Destroy(this.gameObject.GetComponent<Renderer>());
            Destroy(this.gameObject.GetComponent<CircleCollider2D>());
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            GameObject.FindGameObjectWithTag("BabyGlob").GetComponent<BabyHealth>().increceHealth();
        }
        else if(collision.gameObject.tag == "BabyGlob" ) //if Baby is full
        {
            Destroy(this.gameObject.GetComponent<Renderer>());
            Destroy(this.gameObject.GetComponent<CircleCollider2D>());
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && collision.gameObject.GetComponent<PlayerHealth>().CurentHealth < 4)
        {
            Destroy(this.gameObject.GetComponent<Renderer>());
            Destroy(this.gameObject.GetComponent<CircleCollider2D>());
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().increceHealth();
        }
        else if (Input.GetKeyDown(KeyCode.F) ) //If Player is full
        {
            Destroy(this.gameObject.GetComponent<Renderer>());
            Destroy(this.gameObject.GetComponent<CircleCollider2D>());
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        }
    }
}
