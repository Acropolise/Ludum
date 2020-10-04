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
    public AudioClip error;

    public int minEnters = 1;
    public int maxEnters = 3;

    public float newDoorTime = 4;
   
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
            if(Vector3.Distance(cam.transform.position, new Vector3(0, 30, 0)) < 2)
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
            if(newDoorTime > 1.5f)
            {
                newDoorTime -= 0.3f;
            }
            timer.maxTime += 3.5f;
                timer.ResetTimer();
            minEnters++;
            maxEnters++;
            requiredEnters = Random.Range(minEnters, maxEnters);
            StartCoroutine(TextRoutine());
            currentLevel++;
                Spawn();
                currentEnters = 0;
                timerObj.SetActive(true);
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
        StartCoroutine(TextRoutine());
        if(!src.isPlaying)
        {
            src.PlayOneShot(error, 1);
        }    

        currentEnters = 0;
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
        text.text = "ENTER " + requiredEnters + " DOORS";
        yield return new WaitForSeconds(3);
        text.gameObject.SetActive(false);
    }





}
