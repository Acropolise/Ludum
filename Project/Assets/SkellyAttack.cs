using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyAttack : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var angle = other.transform.position - transform.position;
            var dist = angle.magnitude;
            var direction = angle / dist;

            Rigidbody rb = other.GetComponent<Rigidbody>();

            rb.AddForce(Vector3.forward * direction.sqrMagnitude * 4000, ForceMode.Impulse);
            rb.AddForce(Vector3.up * 4000, ForceMode.Impulse);

        }

    }


}
