using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    [Header("Dynamic")]
    static private int _level = 0;
    
    static private TextMeshProUGUI uiText;

    void Awake() 
    {
        uiText = GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("LevelCounter")){
            Level = PlayerPrefs.GetInt("LevelCounter");
        }
        PlayerPrefs.SetInt("LevelCounter", Level);
    }

    static public int Level
    {
        get { return _level; }
        private set{
            _level = value;
            PlayerPrefs.SetInt("LevelCounter", value);
            if (uiText != null) {
                uiText.text = "Level: " + value.ToString("#,0");
            }
        }
    }


    static public void SetLevel(int newLevel)
    {
        Level = newLevel;
    }
}

