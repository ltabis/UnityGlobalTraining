using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    /* class for timer behaviour */

    private Text clockTest;
    private bool end = false;
    public float startTime = 300;
    
    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        float currentTime = (end ? 0 : startTime - Time.time );
        float min = (int)(currentTime / 60.0);
        float sec = Mathf.Floor(currentTime) % 60;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = (min < 10 ? "0" + min.ToString() : min.ToString())
            + " : " + (sec < 10 ? "0" + sec.ToString() : sec.ToString());
        if (!end && currentTime <= 0)
            end = true;
    }

    // Get Ellapsed time since start of the wave
    public float GetRemainingTime()
    {
        return (end ? startTime - Time.time : 0);
    }

    // Get state of the timer
    public bool IsEnd()
    {
        return end;
    }
}
