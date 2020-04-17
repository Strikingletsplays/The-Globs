using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        MoveCrosshair();
    }
    private void MoveCrosshair()
    {
        transform.position = Input.mousePosition;
    }
}
