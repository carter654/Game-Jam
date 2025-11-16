using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesCounter : MonoBehaviour
{
    [Header("Dynamic")]

    static private int _lives = -1;

    static private TextMeshProUGUI uiText;

    void Awake()
    {
        uiText = GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("LivesCounter")){
            Lives = PlayerPrefs.GetInt("LivesCounter");
        }
        PlayerPrefs.SetInt("LivesCounter", Lives);
        PlayerPrefs.Save();
    }

    static public int Lives
    {
        get { return _lives; }
        set{
            _lives = value;
            PlayerPrefs.SetInt("LivesCounter", value);
            PlayerPrefs.Save();
            uiText.text = "Lives: " + value.ToString("#,0");
            
        }
    }

    static public void SetLives(int newLives)
    {
        Lives = newLives;
    }
}
