using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{

    public Transform player;
    public Animator anim;
    public NavMeshAgent agent;
   

    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < 10)
        {
            if((Vector3.Distance(transform.position, player.position) < 4.25f))
            {
                agent.isStopped = true;
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
            else
            {
                agent.isStopped = false;
                agent.SetDestination(player.position);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }

        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("isWalking", false);
        }
        
   

    }


    
}
