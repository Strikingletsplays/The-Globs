﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Vector2.Distance(transform.position, Player.position) < FollowRange)
        {
            if (!(Vector2.Distance(transform.position, Player.position) < stopRange))
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
                //flip to players direction
                if(Player.position.x > this.transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0); // flip right
                    Canvas.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 0, this.transform.eulerAngles.z);
                }
                else if (Player.position.x < transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0); //flip left
                    Canvas.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 180, this.transform.eulerAngles.z);
                }
                if (transform.localScale.x < 0) // If he is placed by parent with inverse scale
                {
                    if (Player.position.x > this.transform.position.x)
                    {
                        transform.eulerAngles = new Vector3(0, 180, 0);
                        Canvas.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 0, this.transform.eulerAngles.z);
                    }
                    else if (Player.position.x < transform.position.x)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        Canvas.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 180, this.transform.eulerAngles.z);
                    }
                }
                if ((Player.position.y - this.transform.position.y) > 2.2 && m_Grounded)
                {
                    //jump
                    this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
                }
            }
        }
        
    }
}
