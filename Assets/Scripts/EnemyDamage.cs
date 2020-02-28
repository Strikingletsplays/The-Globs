using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ParentGlob")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-20,10);
        }
        if (collision.gameObject.name == "babyglob")
        {
            //kill baby
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
