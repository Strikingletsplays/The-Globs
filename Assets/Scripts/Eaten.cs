using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eaten : MonoBehaviour
{
    private BabyHealth BabyHealth;
    private PlayerGlow Glow;
    private Image EatBGlow;
    private void Awake()
    {
        Glow = GameObject.FindGameObjectWithTag("GlowBar").GetComponent<PlayerGlow>();
        EatBGlow = GameObject.FindGameObjectWithTag("GainGlow").GetComponent<Image>();
        BabyHealth = this.GetComponent<BabyHealth>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Ui Enable
            EatBGlow.enabled = true;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Glow.IncreseGlow(BabyHealth.Health);
                BabyHealth.isdead();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Ui Enable
            EatBGlow.enabled = true;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Glow.IncreseGlow(BabyHealth.Health);
                BabyHealth.isdead();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Ui Enable
            EatBGlow.enabled = false;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Glow.IncreseGlow(BabyHealth.Health);
                BabyHealth.isdead();
            }
        }
    }
}
