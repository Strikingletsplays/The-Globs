using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWater : MonoBehaviour
{
    public GameObject FirePoint;
    public GameObject Water;
    private GameObject ParticleSystem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ParticleSystem = Instantiate(Water, FirePoint.transform.position, Quaternion.Euler(0,90f,0));
            ParticleSystem.gameObject.SetActive(true);
            ParticleSystem.GetComponent<ParticleSystem>().Play();
        }
        if (ParticleSystem) //if water is spawned
        {
            ParticleSystem.transform.position = FirePoint.transform.position;
            ParticleSystem.transform.rotation = Quaternion.Inverse(ParticleSystem.transform.rotation);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            ParticleSystem.GetComponent<ParticleSystem>().Stop();
            Destroy(ParticleSystem, 3);
        }
    }
}
