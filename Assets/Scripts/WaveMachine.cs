using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveMachine : MonoBehaviour
{
    [SerializeField] private int wave = 1;
    [SerializeField] private int range = 10;

    // prefab for Enemy
    public GameObject EnemyPrefab;
    // prefab for GUI
    public UnityEngine.UI.Text TimerPrefab;
    
    // Generated GUI
    private UnityEngine.UI.Text timerInstance;
    // Timer script
    Timer script;

    // Start is called before the first frame update
    void Start()
    {
        timerInstance = Instantiate(TimerPrefab);
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
        generatEnemies();
        script.Launch(wave * range);
    }

    private void generatEnemies()
    {
        for (int i = 0; i < wave; i++)
        {
            GameObject newEnemy = Instantiate(EnemyPrefab);
            newEnemy.name = "Enemy" + i;
            newEnemy.GetComponent<Transform>().position = new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(-30.0f, 30.0f), 0);
        }
    }
}
