using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    private Vector3 PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    public float Speed = 2;

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x - PlayerPos.x < 2)
        {
            transform.position = transform.forward * Speed * Time.deltaTime;
        }
    }
}
