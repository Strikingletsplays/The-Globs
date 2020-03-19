using UnityEngine;

public class pickup : MonoBehaviour
{
    private Transform PlayersHoldingPossition;
    public bool isHolding = false;
    public bool isClose;
    private float distance;

    void Start()
    {
        PlayersHoldingPossition = GameObject.FindGameObjectWithTag("Destination").transform;
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, PlayersHoldingPossition.position);
        isClose = distance < 1f;
    }

    void OnMouseDown()
    {
        if (isClose)
        {
            isHolding = true;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
