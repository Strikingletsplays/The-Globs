using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ParentGlob")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 400.0f);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.forward * 400.0f);
        }
        if (collision.gameObject.tag == "BabyGlob")
        {
            collision.gameObject.GetComponent<BabyHealth>().TakeDamage();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 400.0f);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.forward * 400.0f);
        }
    }
}
