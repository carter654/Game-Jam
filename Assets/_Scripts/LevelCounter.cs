using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    [Header("Dynamic")]
    static private int level = 0;

    private TextMeshProUGUI uiText;

    void Awake() 
    {
        uiText = GetComponent<TextMeshProUGUI>();

        if (PlayerPrefs.HasKey("LevelCounter")){
            level = PlayerPrefs.GetInt("LevelCounter");
        }
        PlayerPrefs.SetInt("LevelCounter", level);
    }

    static public int Level
    {
        get { return level; }
    }

    static public void IncrementLevel()
    {
        level++;
        PlayerPrefs.SetInt("LevelCounter", level);
    }

    static public void DecrementLevel()
    {
        level--;
        PlayerPrefs.SetInt("LevelCounter", level);
    }

    static public void ResetLevel()
    {
        level = 0;
        PlayerPrefs.SetInt("LevelCounter", level);
    }

    void Update()
    {
        uiText.text = level.ToString("#,0");
    }
}

