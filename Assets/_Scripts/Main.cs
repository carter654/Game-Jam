using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class General : MonoBehaviour
{

    public Timer timer;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject timerGO = GameObject.Find("Timer");
        timer = timerGO.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTime();
    }

    void CheckTime()
    {
        float currentTime = timer.m_Time;
        if (currentTime >= 0)
        {
            // Do something with the player
        }
    }
}
