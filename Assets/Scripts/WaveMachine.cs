using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveMachine : MonoBehaviour
{
    [SerializeField] private int wave = 1;
    [SerializeField] private int range = 10;

    // prefab for GUI
    public UnityEngine.UI.Text TimerUI;
    // Generated GUI
    private UnityEngine.UI.Text timerInstance;
    // Timer script
    Timer script;

    // Start is called before the first frame update
    void Start()
    {
        timerInstance = Instantiate(TimerUI);
        timerInstance.transform.SetParent(GameObject.Find("Canvas").transform);
        timerInstance.name = "weaponTimer";
        script = GameObject.FindObjectOfType(typeof(Timer)) as Timer;
        script.Launch(wave * range);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextWave()
    {
        wave += 1;
        script.Launch(wave * range);
    }
}
