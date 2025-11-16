using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject CheckPointPrefab;

    public Timer timer;

    public int curCheckPointLevel = 0;

    public int timeToBeat = 0;

    public int numOfLivesToGive = 0;

    public GameOver gameOver;


    void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
        CheckPointPrefab = gameObject;

        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Checkpoint reached at level " + curCheckPointLevel);
            if (curCheckPointLevel > 0  && curCheckPointLevel > LevelCounter.Level)
            {
                gameOver.ShowGameOver();
            }
            if (LevelCounter.Level < curCheckPointLevel)
            {
                LevelCounter.SetLevel(curCheckPointLevel);
                timer.m_Time = timeToBeat;
                LivesCounter.SetLives(numOfLivesToGive);
            }
        }
    }
}
