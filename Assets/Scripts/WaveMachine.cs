using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveMachine : MonoBehaviour
{
    public int wave = 1;
    public int range = 10;
    public UnityEngine.UI.Text TimerUI;
    private UnityEngine.UI.Text timerInstance;

    // Start is called before the first frame update
    void Start()
    {
        timerInstance = Instantiate(TimerUI);
        timerInstance.transform.SetParent(GameObject.Find("Canvas").transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextWave()
    {

    }
}
