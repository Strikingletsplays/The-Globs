using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    private Transform PlayerPos;
    public float Speed = 3;
    public float MinDistance = 6;

    // Update is called once per frame
    void Update()
    {
        //Find and chase player
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector2.Distance(this.transform.position, PlayerPos.position) < MinDistance)
        {
            //Play starting animation
            GetComponent<Animator>().SetTrigger("Start");
            StartCoroutine(start()); //Reset start and make enemy follow player.
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("isMoving", false);
        }

        //if Atacking
        if (Vector2.Distance(this.transform.position, PlayerPos.position) < 1.5)
        {
            GetComponentInChildren<Animator>().SetBool("isAtacking", true);
        }
        else { GetComponentInChildren<Animator>().SetBool("isAtacking", false); }

        //Rotating Enemy to face player
        if (this.transform.position.x - PlayerPos.position.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    IEnumerator start()
    {
        yield return new WaitForSeconds(0.7f);
        GetComponent<Animator>().ResetTrigger("Start");
        GetComponentInChildren<Animator>().SetBool("isMoving", true);
        transform.position = Vector2.MoveTowards(transform.position, PlayerPos.position, Speed * Time.deltaTime);
        yield return null;
    }
}
