using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private BoxCollider2D trigger;
    private void Start()
    {
        trigger = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trigger.enabled = false;
            StartCoroutine(disableTrigger());
            collision.GetComponent<PlayerHealth>().TakeDamage();
            collision.GetComponent<Rigidbody2D>().AddForce(transform.up * 400.0f);
            collision.GetComponent<Rigidbody2D>().AddForce(transform.forward * 400.0f);
        }
        if (collision.tag == "BabyGlob")
        {
            trigger.enabled = false;
            StartCoroutine(disableTrigger());
            collision.GetComponent<BabyHealth>().TakeDamage();
            collision.GetComponent<Rigidbody2D>().AddForce(transform.up * 400.0f);
            collision.GetComponent<Rigidbody2D>().AddForce(transform.forward * 400.0f);
        }
    }
    IEnumerator disableTrigger()
    {
        yield return new WaitForSeconds(2);
        trigger.enabled = true;
        yield return null;
    }
}
