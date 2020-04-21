using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWater : MonoBehaviour
{
    public GameObject FirePoint;
    public GameObject Water;
    private GameObject ParticleSystem;
    private Transform Player;
    public bool triggerTurn = true;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ParticleSystem = Instantiate(Water, FirePoint.transform.position, Quaternion.Euler(0,90f,0));
            ParticleSystem.GetComponent<ParticleSystem>().Play();
        }
        if (Player.rotation.y == -1 && ParticleSystem)
        {
            if (triggerTurn)
            {
                triggerTurn = false;
                ParticleSystem.transform.rotation = Quaternion.Inverse(ParticleSystem.transform.rotation); //for shooting left
            }
        }
        else
        {
            triggerTurn = true;
        }
        if (ParticleSystem) //if water is spawned
        {
            ParticleSystem.transform.position = FirePoint.transform.position;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            ParticleSystem.GetComponent<ParticleSystem>().Stop();
            Destroy(ParticleSystem, 4);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //enable ui (Press E to pickup shoot)
    }
}
