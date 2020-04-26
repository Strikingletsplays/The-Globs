using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    public Image CharMove;
    public Image PickUpObjects;
    public Image Jump;
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
        if((collision.tag == "Player")) {
            PickUpObjects.enabled = false;
            Jump.enabled = true;
            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(jumpdelay());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.tag == "Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(jumpdelay());
            }
        }
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
    IEnumerator jumpdelay()
    {
        yield return new WaitForSeconds(2);
        Jump.enabled = false;
        SecondTrigger.enabled = false;
    }
}
