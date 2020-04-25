using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
        if (Input.GetMouseButtonDown(0))
        {
           this.GetComponent<Image>().color = Color.green;
        }
        if (Input.GetMouseButtonUp(0))
        {
           this.GetComponent<Image>().color = Color.white;
        }
    }
    private void MoveCrosshair()
    {
        transform.position = Input.mousePosition;
    }
}
