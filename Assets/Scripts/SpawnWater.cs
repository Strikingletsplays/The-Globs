using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWater : MonoBehaviour
{
    public CharacterController2D controller;
    public GameObject FirePoint;
    public GameObject Water;
    GameObject ParticleSystem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ParticleSystem = Instantiate(Water, FirePoint.transform.position, Quaternion.Euler(0, 90, 0));
            ParticleSystem.GetComponent<ParticleSystem>().Play();
            ParticleSystem.transform.position = FirePoint.transform.position;
            ParticleSystem.gameObject.SetActive(true);
        }
        if (ParticleSystem) //if water is spawned
        {
            ParticleSystem.transform.position = FirePoint.transform.position;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            ParticleSystem.GetComponent<ParticleSystem>().Stop();
        }
    }
}
