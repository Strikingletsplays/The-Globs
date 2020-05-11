using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public float rayLength;
    public LayerMask PickableLayers;

    private void Start()
    {
        Cursor.visible = false; //disable default mouse cursor
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero, Color.red);
        MoveCrosshair();
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero, rayLength, PickableLayers);
            if (hit && hit.collider.tag == "BabyGlob")
            {
                this.GetComponent<Image>().color = Color.green;
            }
            if (hit && hit.collider.tag == "Food")
            {
                this.GetComponent<Image>().color = Color.red;
            }
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
