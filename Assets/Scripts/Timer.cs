using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    /* class for timer behaviour */

    public bool start = false;
    public float startTime = 10;
    
    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            float currentTime = startTime - Time.time;
            float min = (int)(currentTime / 60.0);
            float sec = Mathf.Floor(currentTime) % 60;
            gameObject.GetComponent<UnityEngine.UI.Text>().text = (min < 10 ? "0" + min.ToString() : min.ToString())
                + " : " + (sec < 10 ? "0" + sec.ToString() : sec.ToString());
            if (currentTime <= 0)
                start = false;
        }
    }

    // Get Ellapsed time since start of the wave
    public float GetRemainingTime()
    {
        return (start ? startTime - Time.time : 0);
    }

    // Get state of the timer
    public bool IsRunning()
    {
        return start;
    }

    public void Launch(float newTime)
    {
        startTime = newTime;
        start = true;
    }
}
