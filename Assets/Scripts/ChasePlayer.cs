using Pathfinding;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    //This script calls the animator states
    private Animator EnemyAnim;
    private Transform PlayerPos;
    public float MinDistance = 8;
    private PlayerHealth PlayerHealth;
    GameObject parent;
    private void Start()
    {
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        EnemyAnim = GetComponent<Animator>();
        parent = this.transform.parent.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        //Find and chase player
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector2.Distance(transform.position, PlayerPos.position) < MinDistance)
        {
            //For flying enemy
            if (parent.tag == "AI")
            {
                parent.GetComponent<AIPath>().canMove = true;
            }
            if (!(Vector2.Distance(transform.position, PlayerPos.position) < 1))
            {
                RotateEnemyToPlayer();
                EnemyAnim.SetTrigger("isMoving");
            }
        }
        else
        {
            EnemyAnim.ResetTrigger("isMoving");
            EnemyAnim.SetTrigger("isIdle");
            if (parent.tag == "AI")
            {
                parent.GetComponent<AIPath>().canMove = false;
            }
        }
        //if Atacking
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
    void TakeDamage() //Player takes damage
    {
        PlayerHealth.TakeDamage();
    }
}
