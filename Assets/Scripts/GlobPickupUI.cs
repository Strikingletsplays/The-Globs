using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobPickupUI : MonoBehaviour
{
    private GameObject BabyGlob;
    public Image Pickup;
    public List<GameObject> Globs;
    private int CloseBaby;
    // Start is called before the first frame update
    void Start()
    {
        BabyGlob = GameObject.FindGameObjectWithTag("BabyGlob");
        Globs.Add(BabyGlob);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Globs.Count; i++)
        {
            //when pickable object gets destroid
            if (Globs[i] == null)
            {
                CloseBaby = -1;
                Globs.Remove(Globs[i]);
                Pickup.enabled = false;
                continue;
            }
            if (Globs[i].GetComponent<pickup>().isHolding)
            {
                Pickup.enabled = false;
            }
            //UI Pickup object
            if (Globs[i].GetComponent<pickup>().isClose && !Globs[i].GetComponent<pickup>().isHolding)
            {
                CloseBaby = i;
                Pickup.enabled = true;
            }
            else if (Globs[i].GetComponent<pickup>().isClose && Globs[i].GetComponent<pickup>().isHolding)
            {
                Pickup.enabled = false;
            }
        }
        if (CloseBaby != -1 && Globs[CloseBaby] != null)
        {
            if (!Globs[CloseBaby].GetComponent<pickup>().isClose)
            {
                Pickup.enabled = false;
            }
        }else Pickup.enabled = false;
    }
}
