using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    /* class for timer behaviour */

    private Text clockTest;
    private float startTime = 300;
    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        float currentTime = startTime - Time.time;
        string min = ((int)(currentTime / 60.0)).ToString();
        string sec = (currentTime % 60).ToString("f0");
        GameObject.Find("Clock").GetComponent<UnityEngine.UI.Text>().text = min + " : " + sec;
    }
}
