using System.Collections;
using UnityEngine;

public class pickup : MonoBehaviour
{
    private Transform PlayersHoldingPossition;
    public bool isHolding = false;
    public bool isClose;
    private Rigidbody2D objRB;
    private float distance;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
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
            objRB.isKinematic = true;
            objRB.velocity = Vector3.zero;
            gameObject.transform.position = PlayersHoldingPossition.position;
            Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
            transform.parent = GameObject.Find("Destination").transform;
        }
    }
    void OnMouseUp()
    {
        isHolding = false;
        transform.parent = null;
        objRB.gravityScale = 3;
        objRB.isKinematic = false;
        StartCoroutine(EnableCollision());
    }
    IEnumerator EnableCollision()
    {
        yield return new WaitForSeconds(0.5f);
        if(!isHolding)
            Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        yield return null;
    }
}
