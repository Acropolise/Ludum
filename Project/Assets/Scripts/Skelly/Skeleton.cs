using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{

    public Transform player;
    public Animator anim;
    public NavMeshAgent agent;

    public bool canWalk;

    public float range = 10;
   

    void Update()
    {
        if (canWalk)
        {
            if (Vector3.Distance(transform.position, player.position) <= range)
            {
                if ((Vector3.Distance(transform.position, player.position) < 4.25f))
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
        else
        {
            if ((Vector3.Distance(transform.position, player.position) < 4.25f))
            {
                anim.SetBool("isAttacking", true);
            }
            else
            {
                anim.SetBool("isAttacking", false);
            }

        }
        
   

    }


    
}
