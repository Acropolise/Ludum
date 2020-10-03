using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public bool canWalk;
    public float speed = 5f;
    public float rotationSpeed = 1.3f;


    public Transform player;
    public Animator anim;
    public GameObject sword;
   

    void Update()
    {
        Rotate();

        if (canWalk)
        {
            Walk();
        }
        else if (!canWalk)
        {
            Attack();
        }

    }

    private void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < 3.5f)
        {
            anim.SetBool("isAttacking", true);
            anim.SetBool("isWalking", false);
            sword.SetActive(true);
        }
    }

    private void Rotate()
    {
        Vector3 targetPoint = player.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    void Walk()
    {
        if(Vector3.Distance(transform.position, player.position) < 8)
                {

            if (Vector3.Distance(transform.position, player.position) > 3.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                sword.SetActive(false);
            }
            else if (Vector3.Distance(transform.position, player.position) < 3.5f)
            {
                Attack();
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
