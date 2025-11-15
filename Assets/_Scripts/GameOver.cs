using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    [SerializeField] private GameObject gameOverPanel;
    public void ShowGameOver()
    {
        Cursor.visible = true;
        gameOverPanel.SetActive(true);
        Invoke("no", 3);
    }

    private void no()
    {
        Cursor.visible = false;
        gameOverPanel.SetActive(false);
    }

}
