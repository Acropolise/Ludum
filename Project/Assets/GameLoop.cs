using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    public int requiredEnters;
    public int currentEnters;
    public string[] doors = { "Up", " Down", "Right", "Left" };
    public string doorType;

    public Transform[] spawns;
    public Transform player;
    public CharacterController ctrl;

    public TextMeshProUGUI text;
    public CamMovement cam;
    public bool setupNewLevel;

    public int currentLevel = 1;
    public GameObject timerObj;
    public Timer timer;
    bool canLose = true;
    bool resetedLevel = false;
   
    void Start()
    {
        GenerateDoor();
    }

    void Update()
    {
        if(currentEnters >= requiredEnters)
        {
          StartCoroutine(CompleteLevel());

        }

        if(timer.currentTime <= 0 && !resetedLevel && canLose)
        {
            resetedLevel = true;
            Reset();
            resetedLevel = false;
        }
    }

    IEnumerator CompleteLevel()
    {
        cam.zOffset += 35;
        cam.Move();
        timerObj.SetActive(false);
        canLose = false;
        setupNewLevel = false;
        yield return new WaitForSeconds(2.5f);
         
            if(!setupNewLevel)
            {
                timer.maxTime = 7.5f * requiredEnters;
                timer.ResetTimer();
                currentLevel++;
                Spawn();
                currentEnters = 0;
                timerObj.SetActive(true);
                GenerateDoor();
                setupNewLevel = true;
                canLose = true;
            }

        



    }
    public void Enter(Transform spawn)
    {
        ctrl.enabled = false;
        player.position = spawn.position;
        ctrl.enabled = true;

        currentEnters++;
    }



    private void Spawn()
    {
        ctrl.enabled = false;
        player.position = spawns[currentLevel].position;
        ctrl.enabled = true;
    }

    public void Reset()
    {
        Spawn();
        timer.maxTime = 8 * requiredEnters;
        timer.ResetTimer();
        currentEnters = 0;
        GenerateDoor();
    }

    public void GenerateDoor()
    {
        
        requiredEnters = Random.Range(1, 5);
        doorType = doors[Random.Range(0, doors.Length)];
        StartCoroutine(TextRoutine());

    }

    IEnumerator TextRoutine()
    {
        text.gameObject.SetActive(true);
        text.text = "Enter " + doorType + " Door " + requiredEnters + " Times";
        yield return new WaitForSeconds(3.5f);
        text.gameObject.SetActive(false);
    }





}
