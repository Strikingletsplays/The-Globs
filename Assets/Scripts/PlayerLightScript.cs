using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightScript : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "CaveBackground")
        {
            animator.SetTrigger("InCave");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "CaveBackground")
        {
            animator.ResetTrigger("InCave");
            animator.Play("Player_Outside");
        }
    }
}
