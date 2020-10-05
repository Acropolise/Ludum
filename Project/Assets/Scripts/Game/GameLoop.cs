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
    public TextMeshProUGUI timerText;
    public CamMovement cam;
    public bool setupNewLevel;

    public int currentLevel = 1;
    public GameObject timerObj;
    public Timer timer;
    bool canLose = true;

    public GameObject[] lights;
    int doorNum;

    public AudioSource src;
    public AudioClip woosh;
    public AudioClip error;

    public int minEnters = 1;
    public int maxEnters = 3;
    public float newDoorTime = 4;

    public GameObject panel;
    int i;
   
    void Start()
    {
        requiredEnters = Random.Range(minEnters, maxEnters);
        StartCoroutine(TextRoutine());

        GenerateDoor();
    }

    void Update()
    {
        if(currentEnters >= requiredEnters)
        {
          StartCoroutine(CompleteLevel());

        }

        if(timer.currentTime <= 0 && canLose)
        {
            cam.zOffset = 0;
            cam.speed = 21;
            cam.Move();
            timerText.gameObject.SetActive(false);
            if(Vector3.Distance(cam.transform.position, new Vector3(0, 30, 0)) < 3)
            {
                minEnters = 1;
                maxEnters = 3;
                StartCoroutine(TextRoutine());
                cam.speed = 17;
                timer.ResetTimer();
                currentEnters = 0;
                currentLevel = 0;
                newDoorTime = 5;
                timerText.gameObject.SetActive(true);
                cam.zOffset = 45;
                Spawn();
            }
        }
    }

    IEnumerator CompleteLevel()
    {

        cam.Move();
        timerObj.SetActive(false);
        canLose = false;
        setupNewLevel = false;
        yield return new WaitForSeconds(2.8f);
         
            if(!setupNewLevel)
            {
            cam.zOffset += 45;
            if(newDoorTime > 2)
            {
                newDoorTime -= 0.3f;
            }
            timer.maxTime += 3.5f;
                timer.ResetTimer();
            currentEnters = 0;
            i++;
            if(i % 2 == 0)
            {
                minEnters++;
            }
            maxEnters++;
            requiredEnters = Random.Range(minEnters, maxEnters);
            StartCoroutine(TextRoutine());
            currentLevel++;
                Spawn();

                timerObj.SetActive(true);
                setupNewLevel = true;
                canLose = true;
            }

        



    }
    public void Enter(Transform spawn)
    {
        src.PlayOneShot(woosh, 1);
        StartCoroutine(PanelRoutine());
        ctrl.enabled = false;
        player.position = spawn.position;
        ctrl.enabled = true;

        currentEnters++;
    }
    IEnumerator PanelRoutine()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        panel.SetActive(false);

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
            src.PlayOneShot(error, 1);  
        if(currentEnters > 0)
        {
            currentEnters--;
        }

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
        yield return new WaitForSeconds(newDoorTime);
        lights[doorNum].SetActive(false);
        GenerateDoor();
    }

    IEnumerator TextRoutine()
    {
        text.gameObject.SetActive(true);
        if(requiredEnters == 1)
        {
            text.text = "Enter " + requiredEnters + " Door";
        }
        else
        {
            text.text = "Enter " + requiredEnters + " Doors";
        }

        yield return new WaitForSeconds(3);
        text.gameObject.SetActive(false);
    }





}
