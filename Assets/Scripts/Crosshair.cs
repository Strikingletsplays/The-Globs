using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float MouseSensitivity = 0.1f;
    GameObject crosshair;

    private void Start()
    {
        crosshair = GameObject.Find("crosshair");
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 _mousePos = Input.mousePosition;
        crosshair.transform.position = Vector2.Lerp(transform.position, _mousePos, MouseSensitivity);
        print(_mousePos);
    }
}
