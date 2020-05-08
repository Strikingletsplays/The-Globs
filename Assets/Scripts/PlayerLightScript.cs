using UnityEngine;

public class PlayerLightScript : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "CaveBackground" || collision.name == "LightColider")
        {
            animator.SetTrigger("InCave");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "CaveBackground" || collision.name == "LightColider")
        {
            animator.ResetTrigger("InCave");
            animator.Play("Player_Outside");
        }
    }
}
