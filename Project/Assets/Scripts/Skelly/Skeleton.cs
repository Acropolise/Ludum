using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{

    public Transform player;
    public Animator anim;
    public GameObject sword;
    public NavMeshAgent agent;
   

    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < 14)
        {
            if((Vector3.Distance(transform.position, player.position) < 4))
            {
                sword.SetActive(true);
                agent.isStopped = true;
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
            else
            {
                sword.SetActive(false);
                agent.isStopped = false;
                agent.SetDestination(player.position);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }

        }

        
   

    }


    
}
