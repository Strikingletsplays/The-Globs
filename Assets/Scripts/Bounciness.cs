using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounciness : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
       collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 200.0f);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 200.0f);
    }
}
