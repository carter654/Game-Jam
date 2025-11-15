using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesCounter : MonoBehaviour
{
    [Header("Dynamic")]

    static private int _lives = 0;

    static private TextMeshProUGUI uiText;

    void Awake()
    {
        uiText = GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("LevelCounter")){
            Lives = PlayerPrefs.GetInt("LevelCounter");
        }
        PlayerPrefs.SetInt("LevelCounter", Lives);
    }

    static public int Lives
    {
        get { return _lives; }
        set{
            _lives = value;
            PlayerPrefs.SetInt("LevelCounter", value);
            uiText.text = "Lives: " + value.ToString("#,0");
            
        }
    }

    static public void SetLives(int newLives)
    {
        Lives = newLives;
    }
}
