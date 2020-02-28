using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pickup : MonoBehaviour
{
    private Transform theDest;
    private Transform player;
    private bool isHolding;

    void Awake()
    {
        theDest = GameObject.FindGameObjectWithTag("Destination").transform;
        isHolding = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        if (isHolding)
        {
            this.GetComponent<Rigidbody2D>().simulated = false;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        
    }
    void OnMouseDown()
    {
        //Debug.Log(player.position.x - me.transform.position.x);
        if (((player.position.x - this.transform.position.x) < 1.5 && (player.position.y - this.transform.position.y) < 1))
        {
            isHolding = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            this.gameObject.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("Destination").transform;
        }
    }
    void OnMouseUp()
    {
        isHolding = false;
        this.transform.parent = null;
        GetComponent<Rigidbody2D>().gravityScale = 3;
        this.GetComponent<Rigidbody2D>().simulated = true;
    }

}
