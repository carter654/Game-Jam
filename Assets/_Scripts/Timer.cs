using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Dynamic")]
    static private float m_Time = 0;

    public bool m_Running = false;

    private TextMeshProUGUI uiText;

    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        uiText.text = m_Time.ToString("#,0");
    }

    void FixedUpdate()
    {
        if (m_Running)
        {
            m_Time += Time.fixedDeltaTime;
        }
    }

    static public float TimeElapsed
    {
        get { return m_Time; }
    }

    static public void SetTime(float newTime)
    {
        m_Time = newTime;
    }

    static public void ResetTime()
    {
        m_Time = 0;
    }
}
