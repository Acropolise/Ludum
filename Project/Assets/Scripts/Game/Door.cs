using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorType;
    public GameLoop gameLoop;
    public Transform oppositePos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameLoop.doorType == doorType)
        {
            gameLoop.Enter(oppositePos);

        }
        else
        {
            gameLoop.Reset();
        }
    }
}
