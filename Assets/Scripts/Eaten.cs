using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eaten : MonoBehaviour
{
    private pickup pickup;
    private BabyHealth BabyHealth;
    private PlayerGlow Glow;
    private Image EatBGlow;
    private void Awake()
    {
        Glow = GameObject.FindGameObjectWithTag("GlowBar").GetComponent<PlayerGlow>();
        EatBGlow = GameObject.FindGameObjectWithTag("GainGlow").GetComponent<Image>();
        BabyHealth = this.GetComponent<BabyHealth>();
        pickup = this.GetComponent<pickup>();
    }
    private void Update()
    {
        if (pickup.isClose && !pickup.isHolding)
        {
            //Ui Enable
            EatBGlow.enabled = true;
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Glow.IncreseGlow(BabyHealth.Health);
                BabyHealth.isdead();
            }
        }
        if (!pickup.isClose)
        {
            //Ui Enable
            EatBGlow.enabled = false;
        }else if (pickup.isHolding)
        {
            //Ui Enable
            EatBGlow.enabled = false;
        }
    }
}
