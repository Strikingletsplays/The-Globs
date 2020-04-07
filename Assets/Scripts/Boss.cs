using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator BossAnim;
    private Transform PlayerPos;
    public float timeBetweenAtack = 1.5f;
    public float Speed = 2;
    public float MinDistance = 6;
    private void Start()
    {
        BossAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Find and chase player
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector2.Distance(transform.position, PlayerPos.position) < MinDistance)
        {
            if (!(Vector2.Distance(transform.position, PlayerPos.position) < 1))
            {
                RotateEnemyToPlayer();
                BossAnim.SetBool("isMoving", true);
                transform.position = Vector2.MoveTowards(transform.position, PlayerPos.position, Speed * Time.deltaTime);
            }
            else 
            { 
                transform.position = transform.position;
            }
        }
        else 
        { 
            BossAnim.SetBool("isMoving", false);
        }
        //if Atacking
        if (Vector2.Distance(transform.position, PlayerPos.position) < 1.5)
        {
            BossAnim.SetBool("isAtacking", true);
        }
        else 
        {
            BossAnim.SetBool("isAtacking", false);
        }
    }
    void RotateEnemyToPlayer()
    {
        //Rotating Enemy to face player
        if (transform.position.x - PlayerPos.position.x < 0)
        {
            transform.localScale = new Vector3(0.59929f, 0.59929f, 0.59929f);
        }
        else
        {
            transform.localScale = new Vector3(-0.59929f, 0.59929f, 0.59929f);
        }
    }
}
