using Pathfinding;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField]
    private Sprite dead;
    //This script calls the animator states
    private Animator EnemyAnim;
    private Transform PlayerPos;
    public float MinDistance = 8;
    private PlayerHealth PlayerHealth;

    //UI HEALTH
    public Slider BossHealthBar;

    private void Start()
    {
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        EnemyAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!EnemyAnim.GetBool("isDead"))
        {
            //Find and chase player
            PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;

            // Stage 2
            if (BossHealthBar.value < 3 && BossHealthBar.value > 0)
            {
                EnemyAnim.SetBool("Stage2", true);
            }
            if (Vector2.Distance(transform.position, PlayerPos.position) < MinDistance && !EnemyAnim.GetBool("isDead"))
            {
                Atack();
                RotateEnemyToPlayer();
                EnemyAnim.SetTrigger("isMoving");
            }
            else if (!EnemyAnim.GetBool("isDead"))
            {
                EnemyAnim.ResetTrigger("isMoving");
                EnemyAnim.SetTrigger("isIdle");
            }
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
    void DealDamage() //Boss Deals damage
    {
        if(Vector2.Distance(transform.position, PlayerPos.position) < 1.5)
            PlayerHealth.TakeDamage();
    }
    void TakeDamage()
    {
        EnemyAnim.SetTrigger("isHurt");
        BossHealthBar.value -= 1;
        if (BossHealthBar.value == 0) //when dead
        {
            EnemyAnim.ResetTrigger("isAtacking");
            EnemyAnim.ResetTrigger("isHurt");
            EnemyAnim.SetTrigger("isDead");
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Water")
        {
            int randNum = Random.Range(0, 10000);
            if (randNum > 9900)
            {
                TakeDamage();
            }
        }
    }
    void DisableAnimator()
    {
        //SET SPRITE TO DEAD.
        GetComponent<SpriteRenderer>().sprite = dead;
        GetComponent<Animator>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<ChasePlayer>().enabled = false;
    }
}
