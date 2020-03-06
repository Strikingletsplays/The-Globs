using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladders : MonoBehaviour
{
    public float climeSpeed = 3;
    private Animator anim;

    private void OnTriggerStay2D(Collider2D other)
    {
        anim = other.GetComponent<Animator>();
        if ((other.tag=="Player" || other.tag == "BabyGlob") && Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isClimbing", true);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, climeSpeed);
            other.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else if (other.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isClimbing", true);
            other.GetComponent<Rigidbody2D>().gravityScale = 0;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -climeSpeed);
        }
        else
        {
            anim.SetBool("isClimbing", false);
            other.GetComponent<Rigidbody2D>().gravityScale = 3;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("isClimbing", false);
        collision.GetComponent<Rigidbody2D>().gravityScale = 3;
        collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
