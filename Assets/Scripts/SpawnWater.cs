using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWater : MonoBehaviour
{
    public GameObject FirePoint;
    public GameObject Water;          //water obj.
    private GameObject waterPS = null;  //particles to spawn
    private Transform Player;         //for rotation
    private WaterGun WaterGun;

    private void Start()
    {
        WaterGun = GetComponent<WaterGun>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && WaterGun.isHoldingGun) //if shoot and holding watergun
        {
            waterPS = Instantiate(Water, FirePoint.transform.position, Quaternion.Euler(0, 90f, 0));
            waterPS.transform.position.Normalize();
            waterPS.GetComponent<ParticleSystem>().Play();
        }
        if (waterPS && Player.rotation.y < 0 )
        {
            waterPS.transform.rotation = Quaternion.Euler(0, -90f, 0); //for shooting left
        }
        else if (waterPS && Player.rotation.y > 0)
        {
            waterPS.transform.rotation = Quaternion.Euler(0, 90f, 0); //for shooting right
        }
        if (waterPS) //if water is spawned
        {
            waterPS.transform.position = FirePoint.transform.position;
        }

        if (waterPS && Input.GetKeyUp(KeyCode.E))  //Destroy particle system
        {
            waterPS.GetComponent<ParticleSystem>().Stop();
            Destroy(waterPS, 4);
        }
    }

}
