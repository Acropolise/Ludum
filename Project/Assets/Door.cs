using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorType;
    public GameLoop gameLoop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameLoop.doorType == doorType)
        {
            gameLoop.Entered();

        }
        else
        {
            gameLoop.Reset();
        }
    }
}
