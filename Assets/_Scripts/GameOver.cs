using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] private GameObject gameOverPanel;

    public void ShowGameOver()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("_Scene_0");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
