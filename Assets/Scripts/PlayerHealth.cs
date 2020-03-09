using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 4;
    public int Health;
    private Vector3 ScaleChangeSize;
    public GameObject baby;
    public Image NewBaby;
    //Spawn Baby
    private Transform SpawnBaby; //Position
    public GlobPickupUI AllBabys; // Add to list of globs
    //Flip canvas
    public Canvas Canvas;
    //Ui
    public HealthBar healthbar;
    public Image Pickup;
    // Start is called before the first frame update
    void Start()
    {
        Health = 2;
        healthbar.SetMaxHealth(MaxHealth);
        healthbar.SetHealth(Health);
        SpawnBaby = GameObject.FindGameObjectWithTag("Destination").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //flip canvas
        if (transform.localScale.x < 0)
        {
            Canvas.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
        }
        else
        {
            Canvas.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 0, transform.eulerAngles.z);
        }
        if (Health <= 0)
        {
            //enable death gui
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //fix health going over 4 
        if (Health > 4)
        {
            Health = 4;
        }
    }
    public void TakeDamage()
    {
        if (this.gameObject.GetComponent<Transform>().localScale.x > 0)
        {
            ScaleChangeSize = new Vector3(-0.3f, -0.3f, -0.3f);
            this.transform.localScale += ScaleChangeSize;
        }
        else
        {
            ScaleChangeSize = new Vector3(0.3f, -0.3f, -0.3f);
            this.transform.localScale += ScaleChangeSize;
        }
        Health -= 1;
        healthbar.SetHealth(Health);
    }
    public void increceHealth()
    {
        if (Health < 4)
        {
            //increase scale when he is facing laft or right
            if (this.gameObject.GetComponent<Transform>().localScale.x > 0)
            {
                ScaleChangeSize = new Vector3(0.25f, 0.25f, 0.25f);
                this.transform.localScale += ScaleChangeSize;
            }
            else
            {
                ScaleChangeSize = new Vector3(-0.25f, 0.25f, 0.25f);
                this.transform.localScale += ScaleChangeSize;
            }
            Health++;
            healthbar.SetHealth(Health);
        }else if(Health == 4)
        {
            NewBaby.enabled = true;
            GameObject NewBbay = Instantiate(baby, SpawnBaby.position, transform.rotation);
            AllBabys.Globs.Add(NewBbay);
            //wait for 2 second
            StartCoroutine(disableNewGlobUI(2f));
        }
    }
    IEnumerator disableNewGlobUI(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NewBaby.enabled = false;
        yield return null;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Food")
        {
            //Enable Ui (To Eat the food, Press [F])
            Pickup.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Food")
        {
            //Disable Ui (To Eat the food, Press [F])
            Pickup.enabled = false;
        }
    }
}
