using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyAttack : MonoBehaviour
{
   public Rigidbody rb;
    public CharacterController ctrl;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Skelly");
            var angle = other.transform.position - transform.position;
            var dist = angle.magnitude;
            var direction = angle / dist;

            rb.isKinematic = false;
            ctrl.enabled = false;
            rb.AddForce(Vector3.forward * -direction.sqrMagnitude * 40, ForceMode.Impulse);
            rb.AddForce(Vector3.up * 60, ForceMode.Impulse);
            yield return new WaitForSeconds(0.2f);
            ctrl.enabled = true;
            rb.isKinematic = true;

        }

    }


}
