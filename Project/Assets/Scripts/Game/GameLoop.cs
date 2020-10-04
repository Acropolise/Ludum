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

    public float timeToEachDoor = 8;

    public GameObject[] lights;
    int doorNum;
   
    void Start()
    {
        requiredEnters = Random.Range(1, 4);
        StartCoroutine(TextRoutine());

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

        cam.Move();
        timerObj.SetActive(false);
        canLose = false;
        setupNewLevel = false;
        yield return new WaitForSeconds(3);
         
            if(!setupNewLevel)
            {
            requiredEnters = Random.Range(1, 5);
            cam.zOffset *= 2;
            timeToEachDoor -= 0.75f;
             //   timer.maxTime = timeToEachDoor * requiredEnters;
                timer.ResetTimer();
            StartCoroutine(TextRoutine());
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
    //    timer.maxTime = timeToEachDoor * requiredEnters;
        timer.ResetTimer();
        currentEnters = 0;
        GenerateDoor();
    }

    public void GenerateDoor()
    {
         doorNum = Random.Range(0, doors.Length);
        doorType = doors[doorNum];
        StartCoroutine(Lights());
     

    }
    IEnumerator Lights()
    {
        lights[doorNum].SetActive(true);
        yield return new WaitForSeconds(3);
        lights[doorNum].SetActive(false);
        GenerateDoor();
    }

    IEnumerator TextRoutine()
    {
        text.gameObject.SetActive(true);
        text.text = "You need to enter " + requiredEnters + " doors";
        yield return new WaitForSeconds(3);
        text.gameObject.SetActive(false);
    }





}
