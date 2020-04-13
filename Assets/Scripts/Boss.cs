using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private Animator BossAnim;
    private Transform PlayerPos;
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
                BossAnim.SetTrigger("isMoving");
            }
        }
        else
        {
            BossAnim.ResetTrigger("isMoving");
            BossAnim.SetTrigger("isIdle");
        }
        //if Atacking
        if (Vector2.Distance(transform.position, PlayerPos.position) < 1.5)
        {
            BossAnim.SetTrigger("isAtacking");
        }
        else
        {
            BossAnim.ResetTrigger("isAtacking");
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
