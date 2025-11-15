using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public Timer timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        
        CheckPoint[] allCheckpoints = FindObjectsOfType<CheckPoint>();
        CheckPoint checkPoint = null;
        int targetLevel = LevelCounter.Level;
        foreach (var cp in allCheckpoints)
        {
            if (cp.curCheckPointLevel == targetLevel)
            {
                checkPoint = cp;
                break;
            }
        }
        if (checkPoint == null && allCheckpoints.Length > 0)
        {
            checkPoint = allCheckpoints[0];
        }
        

        timer.m_Time = checkPoint.timeToBeat;
        LivesCounter.SetLives(checkPoint.numOfLivesToGive);
        LevelCounter.SetLevel(checkPoint.curCheckPointLevel);

        Debug.Log("Checkpoint Level: " + checkPoint.curCheckPointLevel + " Time to Beat: " + checkPoint.timeToBeat + " Lives to Give: " + checkPoint.numOfLivesToGive);
        Debug.Log("Starting Level: " + LevelCounter.Level + " with Lives: " + LivesCounter.Lives);

        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = checkPoint.CheckPointPrefab.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

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
                break;
            }
            else if (cp.curCheckPointLevel == targetLevel - 1)
            {
                prevCheckPoint = cp;
            }
        }
        if (checkPoint == null && allCheckpoints.Length > 0)
        {
            checkPoint = allCheckpoints[0];
        }

        timer.m_Time = checkPoint.timeToBeat;
        timer.m_Running = false;

        GameObject player = GameObject.FindWithTag("Player");

        Debug.Log("Current Lives: " + LivesCounter.Lives);

        if (LivesCounter.Lives > 0)
        {
            LivesCounter.SetLives(LivesCounter.Lives - 1);

            player.transform.position = checkPoint.CheckPointPrefab.transform.position;
        }
        else
        {
            if (LevelCounter.Level > 0)
            {
                LevelCounter.SetLevel(LevelCounter.Level - 1);
                LivesCounter.SetLives(prevCheckPoint.numOfLivesToGive);

                player.transform.position = prevCheckPoint.CheckPointPrefab.transform.position;
            }
            else
            {
                LivesCounter.SetLives(checkPoint.numOfLivesToGive);

                player.transform.position = checkPoint.CheckPointPrefab.transform.position;
            }
        }
    }
}
