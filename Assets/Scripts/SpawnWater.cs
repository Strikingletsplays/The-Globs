using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWater : MonoBehaviour
{
    public GameObject FirePoint;
    public GameObject Water;          //water obj.
    private GameObject water = null;  //particles to spawn
    private Transform Player;         //for rotation

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //if shoot
        {
            water = Instantiate(Water, FirePoint.transform.position, Quaternion.Euler(0, 90f, 0));
            water.GetComponent<ParticleSystem>().Play();
        }
        if (Player.rotation.y < 0 && water)
        {
            water.transform.rotation = Quaternion.Euler(0, -90f, 0); //for shooting left
        }
        else if (Player.rotation.y > 0 && water)
        {
            water.transform.rotation = Quaternion.Euler(0, 90f, 0); //for shooting right
        }
        if (water) //if water is spawned
        {
            water.transform.position = FirePoint.transform.position;
        }

        if (Input.GetKeyUp(KeyCode.E))  //Destroy particle system
        {
            water.GetComponent<ParticleSystem>().Stop();
            Destroy(water, 4);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //enable ui (Press E to shoot)
    }
}
