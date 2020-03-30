using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eaten : MonoBehaviour
{
    private BabyHealth BabyHealth;
    private PlayerGlow Glow;
    private void Awake()
    {
        Glow = GameObject.FindGameObjectWithTag("GlowBar").GetComponent<PlayerGlow>();
        BabyHealth = this.GetComponent<BabyHealth>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            Glow.IncreseGlow(BabyHealth.Health);
            BabyHealth.isdead();
        }
    }
}
