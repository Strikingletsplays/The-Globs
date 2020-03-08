﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pickup : MonoBehaviour
{
    public Transform PlayersHoldingPossition;
    public bool isHolding;
    public bool isClose;
    private float distance;

    void Awake()
    {
        isHolding = false;
        PlayersHoldingPossition = GameObject.FindGameObjectWithTag("Destination").transform;
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, PlayersHoldingPossition.position);
        isClose = (distance < .7);
        if (isHolding)
        {
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    void OnMouseDown()
    {
        if (isClose)
        {
            isHolding = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.transform.position = PlayersHoldingPossition.position;
            transform.parent = GameObject.Find("Destination").transform;
        }
    }
    void OnMouseUp()
    {
        isHolding = false;
        transform.parent = null;
        GetComponent<Rigidbody2D>().gravityScale = 3;
        GetComponent<Rigidbody2D>().simulated = true;
    }

}
