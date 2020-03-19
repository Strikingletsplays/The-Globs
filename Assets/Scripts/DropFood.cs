using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropFood : MonoBehaviour
{
    private Transform Player;
    public List<GameObject> apples;
    public Image Click2Shake;
    public Animator anim;
    //isTime is for small delay 
    bool isTime = true;
    private float distance;

    //Sound
    public AudioSource Shake;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        distance = Vector2.Distance(transform.position, Player.position);
        if(distance < 2){
            //Enables RB simulation
            if (Input.GetMouseButtonDown(0) && isTime)
            {
                isTime = false;
                //shake anim
                anim.SetBool("isShaking", true);
                //Sound
                Shake.Play();
                for (int i = 0; i < apples.Count; i++)
                {
                    if (apples[i])
                        if (!(apples[i].GetComponent<Rigidbody2D>().simulated))
                        {
                            apples[i].GetComponent<pickup>().enabled = true;
                            apples[i].GetComponent<Rigidbody2D>().simulated = true;
                            apples.Remove(apples[i]);
                            break;
                        }
                }
                //Delay, so double clicks dont drop 2
                Invoke("setTimer", 0.5f);
                Click2Shake.enabled = false;
            }
        }
        //Clean list (removes null obj)
        for(int i = 0; i<apples.Count; i++)
        {
            if (apples[i] == null)
                apples.Remove(apples[i]);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player") { 
        if(apples.Count != 0)
            Click2Shake.enabled = true;
        else
            Click2Shake.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Click2Shake.enabled = false;
    }
    void setTimer()
    {
        isTime = true;
        anim.SetBool("isShaking", false);
    }
}
