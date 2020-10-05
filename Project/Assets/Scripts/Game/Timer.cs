using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float maxTime = 20;
    public float currentTime;
    public TextMeshProUGUI text;
    public GameLoop gameLoop;
    public bool startCount;


    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (startCount)
        {


            currentTime -= Time.deltaTime;
            text.text = currentTime.ToString("f2");
        }
    }

    public void ResetTimer()
    {
        currentTime = maxTime;
    }


}
