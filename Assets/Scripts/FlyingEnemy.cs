using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private GameObject parent;
    private Transform PlayerPos;
    private Animator EnemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        EnemyAnim = GetComponent<Animator>();
        parent = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector2.Distance(transform.position, PlayerPos.position) < 7)
        {
            parent.GetComponent<AIPath>().canMove = true;
            RotateEnemyToPlayer();
            EnemyAnim.SetTrigger("isMoving");
            Atack();
        }
        else
        {
            parent.GetComponent<AIPath>().canMove = false;
            EnemyAnim.ResetTrigger("isMoving");
            EnemyAnim.SetTrigger("isIdle");
        }
    }
    void Atack()
    {
        if (Vector2.Distance(transform.position, PlayerPos.position) < 1.5)
        {
            EnemyAnim.SetTrigger("isAtacking");
        }
        else
        {
            EnemyAnim.ResetTrigger("isAtacking");
        }
    }
    void RotateEnemyToPlayer()
    {
        //Rotating Enemy to face player
        if (transform.position.x - PlayerPos.position.x < 0)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(-transform.rotation.x, -180, transform.rotation.z);
        }
    }
}
