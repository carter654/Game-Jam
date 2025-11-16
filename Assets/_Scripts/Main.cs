using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public Timer timer;

    public GameObject FallingRockPrefab;

    public float rockSpawnInterval = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rockSpawnInterval = Random.Range(1f, 7f);

        timer = FindObjectOfType<Timer>();

        Debug.Log("Starting Level: " + LevelCounter.Level + " with Lives: " + LivesCounter.Lives);
        
        CheckPoint[] allCheckpoints = FindObjectsOfType<CheckPoint>();
        CheckPoint checkPoint = null;
        int targetLevel;
        if (LevelCounter.Level == -1)
        {
            targetLevel = 0;
        } else
        {
            targetLevel = LevelCounter.Level;
        }
        foreach (var cp in allCheckpoints)
        {
            if (cp.curCheckPointLevel == targetLevel)
            {
                checkPoint = cp;
                break;
            }
        }

        timer.m_Time = checkPoint.timeToBeat;

        if (LevelCounter.Level == -1)
        {
            LevelCounter.SetLevel(checkPoint.curCheckPointLevel);
        }
        if (LivesCounter.Lives == -1)
        {
            LivesCounter.SetLives(checkPoint.numOfLivesToGive);
        }

        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = checkPoint.CheckPointPrefab.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        rockSpawnInterval -= Time.deltaTime;
        if (rockSpawnInterval <= 0 && timer.m_Running)
        {
            SpawnRock();
            rockSpawnInterval = Random.Range(1f, 7f);
        }
    }
    
    static public void ResetPlayer()
    {
        Debug.Log("Time ran out! Resetting player to last checkpoint.");

        Timer timer = FindObjectOfType<Timer>();
        
        CheckPoint[] allCheckpoints = FindObjectsOfType<CheckPoint>();
        CheckPoint checkPoint = null;
        CheckPoint prevCheckPoint = null;
        int targetLevel = LevelCounter.Level;
        foreach (var cp in allCheckpoints)
        {
            if (cp.curCheckPointLevel == targetLevel)
            {
                checkPoint = cp;
            }
            else if (cp.curCheckPointLevel == targetLevel - 1)
            {
                prevCheckPoint = cp;
            }
        }

        timer.m_Running = false;

        GameObject player = GameObject.FindWithTag("Player");

        Debug.Log("Current Lives: " + LivesCounter.Lives);

        if (LivesCounter.Lives > 1)
        {
            LivesCounter.SetLives(LivesCounter.Lives - 1);
            timer.m_Time = checkPoint.timeToBeat;
            player.transform.position = checkPoint.CheckPointPrefab.transform.position;
        }
        else
        {
            if (LevelCounter.Level > 0)
            {
                LevelCounter.SetLevel(LevelCounter.Level - 1);
                LivesCounter.SetLives(prevCheckPoint.numOfLivesToGive);
                timer.m_Time = prevCheckPoint.timeToBeat;
                player.transform.position = prevCheckPoint.CheckPointPrefab.transform.position;
            }
            else
            {
                LivesCounter.SetLives(checkPoint.numOfLivesToGive);
                timer.m_Time = checkPoint.timeToBeat;
                player.transform.position = checkPoint.CheckPointPrefab.transform.position;
            }
        }
    }

    void SpawnRock()
    {
        GameObject rock = Instantiate<GameObject>(FallingRockPrefab);
        rock.transform.position = GameObject.FindWithTag("Player").transform.position + new Vector3(0, 20, 0);
    }
}
