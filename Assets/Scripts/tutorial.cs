using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public Image CharMove;
    public Image PickUpObjects;
    public Image Jump;
    private bool FirstJump = true;
    public BoxCollider2D FirstTrigger;
    public BoxCollider2D SecondTrigger;
    // Start is called before the first frame update
    void Awake()
    {
        Jump.enabled = false;
        PickUpObjects.enabled = false;
        CharMove.enabled = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if((collision.tag == "Player" && FirstJump)) {
            PickUpObjects.enabled = false;
            Jump.enabled = true;
            if (Input.GetKey(KeyCode.Space))
            {
                FirstJump = false;
                Jump.enabled = false;
                SecondTrigger.enabled = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Jump.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FirstTrigger.enabled = false;
            CharMove.enabled = false;
            PickUpObjects.enabled = true;
            if(Input.GetMouseButtonDown(0))
                StartCoroutine(delay(4));
        }
    }
    IEnumerator delay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        PickUpObjects.enabled = false;
    }
}
