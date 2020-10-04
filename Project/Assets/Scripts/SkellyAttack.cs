using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyAttack : MonoBehaviour
{
   public Rigidbody rb;
    public CharacterController ctrl;
    public Movement movement;

    public float force = 30;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
    

            var angle = other.transform.position - transform.position;
            var dist = angle.magnitude;
            var direction = angle / dist;

            rb.isKinematic = false;
            ctrl.enabled = false;
            rb.AddForce(Vector3.forward * -direction.sqrMagnitude * force, ForceMode.Impulse);
            rb.AddForce(Vector3.up * force / 1.3f, ForceMode.Impulse);
            movement.StartCoroutine("ReturnToNormal");


        }

    }




}
