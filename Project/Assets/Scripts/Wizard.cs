using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public GameObject[] effect;
    public float maxTimeBtwAttacks;
    float timeBtwAttacks;
     Animator anim;
    public int i;

    public Transform hitPoint;
    public Transform player;
    public float range = 11f;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < range)
     Attack();
    
    }

    void Attack()
    {
        if (timeBtwAttacks >= maxTimeBtwAttacks)
        {

            int triggerNum = Random.Range(0, 2);
            if (triggerNum == 0)
            {
                anim.SetTrigger("Attack1");
            }
            else if(triggerNum == 1)
            {
                anim.SetTrigger("Attack2");
            }

             i = Random.Range(0, effect.Length);
            GameObject effectObj = Instantiate(effect[i], hitPoint.position, Quaternion.identity);
            Destroy(effectObj, 3);

            timeBtwAttacks = 0;
        }
        else
        {
            timeBtwAttacks += Time.deltaTime;
        }
    }
}
