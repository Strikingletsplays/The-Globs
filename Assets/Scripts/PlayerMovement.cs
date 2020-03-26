using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator Animator;

    public float walkSpeed = 20f;
    float horizontalMove = 0f;
    //float verticalMove = 0f;
    bool jump = false;
    bool crouch = false;
    //Change friction
    public Rigidbody2D player; 
    public PhysicsMaterial2D withFricton;
    public PhysicsMaterial2D noFriction;

    //Sound
    public AudioSource Jump;

    // Update is called once per frame
    void Update()
    {
        //Set walking speed
        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        //Seting friction (so player wont slide)
        if (Input.GetButtonDown("Horizontal"))
        {
            player.sharedMaterial = noFriction;
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            player.sharedMaterial = withFricton;
        }
        //Jumping
        if (Input.GetButtonDown("Jump"))
            {
            if (controller.m_Grounded) //Player is Grounded
            {
                //Play sound
                Jump.Play();
                Animator.SetBool("Isjumping", true);
                jump = true;
            }    
            }
        //Crouching
        if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
         else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
    }
    public void onLanding()
    {
        Animator.SetBool("Isjumping", false);
    }
    private void FixedUpdate()
    {
        //Move our player
        controller.Move(horizontalMove * Time.deltaTime , crouch, jump);
        jump = false;
    }
}
