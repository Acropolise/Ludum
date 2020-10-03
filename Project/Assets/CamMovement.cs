using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{

    public float zOffset;
    public float speed = 5f;
  

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, zOffset), speed * Time.deltaTime);
    }
}
