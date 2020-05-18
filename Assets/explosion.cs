using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(Player.GetComponent<Collider2D>(), GetComponent<PolygonCollider2D>(), true);
        Rigidbody2D.AddForce(new Vector3 (Random.Range(-2f, 6.5f), Random.Range(-2f, 6.5f), 0));
        Rigidbody2D.AddTorque(Random.Range(-7f, 7f));
        this.gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, Random.Range(-0.00001f, -0.0001f)) * Time.deltaTime;
    }
}
