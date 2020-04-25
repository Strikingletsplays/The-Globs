using UnityEngine;

public class pickup : MonoBehaviour
{
    private Transform PlayersHoldingPossition;
    public bool isHolding = false;
    public bool isClose;
    private Rigidbody2D objRB;
    private float distance;

    void Start()
    {
        objRB = GetComponent<Rigidbody2D>();
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
            objRB.gravityScale = 0;
            objRB.simulated = false;
            objRB.velocity = Vector3.zero;
            gameObject.transform.position = PlayersHoldingPossition.position;
            transform.parent = GameObject.Find("Destination").transform;
        }
    }
    void OnMouseUp()
    {
        isHolding = false;
        transform.parent = null;
        objRB.gravityScale = 3;
        objRB.simulated = true;
    }
}
