using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Dynamic")]
    public float m_Time = 0;

    public bool m_Running = false;

    private TextMeshProUGUI uiText;

    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        uiText.text = "Time: " + m_Time.ToString("#,0");
    }

    void FixedUpdate()
    {
        if (m_Running)
        {
            m_Time -= Time.fixedDeltaTime;
            if (m_Time <= 0)
            {
                Main.ResetPlayer();
            }
        }
    }
}
