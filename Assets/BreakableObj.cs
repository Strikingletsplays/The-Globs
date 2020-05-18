using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObj : MonoBehaviour
{
    public GameObject breakableOBJ;
    public int Health = 2;
    private Color damagecolor = new Color32(30, 30, 30, 0);

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(Instantiate(breakableOBJ, transform.position, Quaternion.identity), 4);
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "BabyGlob" )
        {
            Health--;
            GetComponent<SpriteRenderer>().color -= damagecolor;
        }
    }
}
