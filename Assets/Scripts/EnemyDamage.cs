using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage();
            collision.GetComponent<Rigidbody2D>().AddForce(transform.up * 400.0f);
            collision.GetComponent<Rigidbody2D>().AddForce(transform.forward * 400.0f);
        }
        if (collision.tag == "BabyGlob")
        {
            collision.GetComponent<BabyHealth>().TakeDamage();
            collision.GetComponent<Rigidbody2D>().AddForce(transform.up * 400.0f);
            collision.GetComponent<Rigidbody2D>().AddForce(transform.forward * 400.0f);
        }
    }
}
