using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    private Transform PlayerPos;
    public float Speed = 2;
    public float MinDistance = 6;

    // Update is called once per frame
    void Update()
    {
        //Find and chase player
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector2.Distance(this.transform.position, PlayerPos.position) < MinDistance)
        {
            GetComponentInChildren<Animator>().SetBool("isMoving", true);
            transform.position = Vector2.MoveTowards(transform.position, PlayerPos.position,  Speed * Time.deltaTime);
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
}
