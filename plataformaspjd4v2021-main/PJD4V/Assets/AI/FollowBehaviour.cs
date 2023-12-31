using System.Collections;
using System.Collections.Generic;
using AI;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{
    private FollowEnemyController _enemyController;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyController = animator.gameObject.GetComponent<FollowEnemyController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyController.transform.position += (_enemyController.playerTransform.position
                                                - _enemyController.transform.position).normalized
                                               * 2 * _enemyController.moveSpeed * Time.deltaTime;
        
        _enemyController.transform.localScale = _enemyController.playerTransform.position.x < _enemyController.transform.position.x ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
