using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    /* class for timer behaviour */

    [SerializeField] private float duration;
    [SerializeField] private bool start = true;

    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timer -= Time.deltaTime;
            gameObject.GetComponent<UnityEngine.UI.Text>().text = timer.ToString("F");
            if (timer <= 0f)
            {
                gameObject.GetComponent<UnityEngine.UI.Text>().text = "00:00";
                start = false;
            }
            else
            {
                float min = (int)(timer / 60.0);
                float sec = Mathf.Floor(timer) % 60;
                gameObject.GetComponent<UnityEngine.UI.Text>().text = (min < 10 ? "0" + min.ToString() : min.ToString())
                    + " : " + (sec < 10 ? "0" + sec.ToString() : sec.ToString());
            }
        }
        else
        {
            gameObject.GetComponent<UnityEngine.UI.Text>().text = "End of time has come !";
        }
    }

    // Get Ellapsed time since start of the wave
    public float GetRemainingTime()
    {
        return (start ? timer -= Time.deltaTime : 0);
    }

    // Get state of the timer
    public bool IsRunning()
    {
        return start;
    }

    public void Launch(float newTime)
    {
        duration = newTime;
        timer = duration;
        start = true;
    }
}
