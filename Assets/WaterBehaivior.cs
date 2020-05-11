using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaivior : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Tree")
        {
            other.GetComponent<DropFood>().GrowAples();
        }
    }
}
