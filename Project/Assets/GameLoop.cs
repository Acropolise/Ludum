using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public int requiredEnters;
    public int currentEnters;
    public string[] doors = { "Up", " Down", "Right", "Left" };
    public string doorType;

    public Transform spawn;
    public Transform player;
    public CharacterController ctrl;

    public CamMovement cam;
    void Start()
    {
        GenerateDoor();
    }

    void Update()
    {
        if(currentEnters >= requiredEnters)
        {
            CompleteLevel();

        }
    }

    void CompleteLevel()
    {
        cam.Move();
    }

    public void Entered()
    {
        ctrl.enabled = false;

        player.position = spawn.position;
        ctrl.enabled = true;
        currentEnters++;
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   
    }

    public void GenerateDoor()
    {
        requiredEnters = Random.Range(1, 1);
        doorType = doors[Random.Range(0, doors.Length)];
    }



}
