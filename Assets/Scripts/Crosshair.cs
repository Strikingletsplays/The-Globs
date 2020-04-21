﻿using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false; //disable default mouse cursor
    }
    // Update is called once per frame
    void Update()
    {
        MoveCrosshair();
        if (Input.GetMouseButtonDown(0)) {
            //if(gameObject.GetComponent<pickup>())
                this.GetComponent<Image>().color = Color.green;
        }
        if (Input.GetMouseButtonUp(0)) {
            //if(gameObject.GetComponent<pickup>())
                this.GetComponent<Image>().color = Color.white;
        }
    }
    private void MoveCrosshair()
    {
        transform.position = Input.mousePosition;
    }
}
