using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject[] dialogues;
    public int index = 0;
    public TextMeshProUGUI text;
    public GameLoop loop;
    bool alreadyStarted;
    public GameObject timerText;
    public Timer timer;
    public Movement movement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index++;
        }
        for (int i = 0; i < dialogues.Length; i++)
        {

            if (i == index)
            {
                dialogues[i].SetActive(true);
            }
            else
            {
                dialogues[i].SetActive(false);
            }

            if(index > 2 && !alreadyStarted)
            {
                loop.StartGame();
                loop.startedGame = true;
                timerText.SetActive(true);
                text.gameObject.SetActive(false);
                dialogues[i].SetActive(false);
                timer.startCount = true;
                alreadyStarted = true;
                movement.canJump = true;
            }

        }
    }
}
