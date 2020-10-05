using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public float delay = 0.2f;
    public string paragraph;
    string currentText = "";
    public TextMeshProUGUI text;
    void Start()
    {
        StartCoroutine(StartDialogue());

    }
    void Update()
    {
        
    }

    IEnumerator StartDialogue()
    {
        for(int i = 0; i < paragraph.Length; i++)
        {
            currentText = paragraph.Substring(0, i);
            text.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
