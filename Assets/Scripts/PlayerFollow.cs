using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFollow : MonoBehaviour
{
    public float speed;
    public float FollowRange;
    public float stopRange;
    private Transform Player;

    //For checking if glob is gounded
    public float jumpForce;
    private bool m_Grounded;
    const float k_GroundedRadius = .3f; // Radius of the overlap circle to determine if grounded
    [SerializeField] private Transform m_GroundCheck = null;
    [SerializeField] public LayerMask m_WhatIsGround;

    //Flip canvas
    public Canvas Canvas;
    public Image noView;

    //Sound
    public AudioSource Jump;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        m_Grounded = false;
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
            }
        }
        noView.enabled = true;
        if (Vector2.Distance(transform.position, Player.position) < FollowRange)
        {
            noView.enabled = false;
            if (!(Vector2.Distance(transform.position, Player.position) < stopRange))
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.fixedDeltaTime);
                if ((Player.position.y - transform.position.y) > 2.2 && m_Grounded)
                {
                    //jump
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
                    Jump.Play();
                }
            }
        }
        
    }
    private void Update()
    {
        //flip Baby Glob to players direction 
        if (Player.position.x > transform.position.x) //if player is on the right
        {
            if (transform.localScale.x < 0) //if Baby Glob is flipet
            {
                //Debug.Log("When scale Fliped");
                transform.eulerAngles = new Vector3(0, 180, 0); //facing Right
                Canvas.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 0, transform.eulerAngles.z); //UI facing Right
            }
            else
            {
                //Debug.Log("When scale Normal");
                transform.eulerAngles = new Vector3(0, 0, 0);  //facing Right
                Canvas.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 0, transform.eulerAngles.z); //UI facing Right
            }
        }
        else if (Player.position.x < transform.position.x) //if player is on the left
        {
            if (transform.localScale.x < 0) //if Baby Glob is facing right
            {
                //Debug.Log("When scale Fliped");
                transform.eulerAngles = new Vector3(0, 0, 0);  //facing Left
                Canvas.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z); //UI facing Left
            }
            else
            {
                //Debug.Log("When scale Normal");
                transform.eulerAngles = new Vector3(0, 180, 0); //facing Left
                Canvas.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z); //UI facing Left
            }
        }
    }
}
