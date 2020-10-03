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


    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        text.text = "Time: " + currentTime.ToString("f2");
    }

    public void ResetTimer()
    {
        currentTime = maxTime;
    }


}
