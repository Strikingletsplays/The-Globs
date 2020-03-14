using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladders : MonoBehaviour
{
    public float climeSpeed = 3;
    private Animator anim;

    private void OnTriggerStay2D(Collider2D other)
    {
        //For Player
        if (other.tag == "Player")
        {
            anim = other.GetComponent<Animator>();
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.7f);
        }
        if (other.tag=="Player" && Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isClimbing", true);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, climeSpeed);
        }
        if (other.tag == "Player" && Input.GetKey(KeyCode.S) )
        {
            anim.SetBool("isClimbing", true);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -climeSpeed);
        }
        if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && other.tag == "Player" && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            anim.SetBool("isClimbing", false);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            other.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        //for baby globs
        if (other.tag == "BabyGlob")
        {
            anim = other.GetComponent<Animator>();
            this.anim.SetBool("isClimbing", true);
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "BabyGlob")
        {
            anim.SetBool("isClimbing", false);
            collision.GetComponent<Rigidbody2D>().gravityScale = 3;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        
    }
}
