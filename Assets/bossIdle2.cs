using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossIdle2 : StateMachineBehaviour
{
    public orionBoss2 boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<orionBoss2>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.bossIdle();
    }
}
