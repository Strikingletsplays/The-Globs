using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer_Behaviour : StateMachineBehaviour
{
    public Transform player;
    public Transform Enemy;
    public float Speed = 2;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Enemy = GameObject.FindGameObjectWithTag("Boss").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.GetBool("isMoving"))
            Enemy.position = Vector2.MoveTowards(Enemy.position, player.position, Speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
