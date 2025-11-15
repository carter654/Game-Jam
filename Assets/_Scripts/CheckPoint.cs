using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject CheckPointPrefab;

    public LevelCounter levelCounter;

    public Timer timer;

    public int curCheckPointLevel = 0;

    public int timeToBeat = 0;

    public GameOver gameOver;


    void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
        CheckPointPrefab = GetComponent<GameObject>();

        GameObject levelGO = GameObject.Find("LevelCounter");
        levelCounter = levelGO.GetComponent<LevelCounter>();

        GameObject timerGO = GameObject.Find("Timer");
        timer = timerGO.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameOver.ShowGameOver();
            if (LevelCounter.Level < curCheckPointLevel)
            {
                // levelCounter.SetLevel(curCheckPointLevel);
                // timer.SetTime(timeToBeat);
            }
        }
    }
}
