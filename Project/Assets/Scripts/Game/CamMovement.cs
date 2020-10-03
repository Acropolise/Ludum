using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{

    public float zOffset;
    public float speed = 5f;
  

    public void Move()
    {
        Vector3 movement = new Vector3(transform.position.x, transform.position.y, zOffset);

      transform.position = Vector3.MoveTowards(transform.position, movement, speed * Time.deltaTime);

    }


}
