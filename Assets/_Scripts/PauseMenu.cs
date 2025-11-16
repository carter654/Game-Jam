using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    private Main Main;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GamePaused){
                resume();
            }else{
                pause();
            }
        }
    }

    public void resume(){
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void pause(){
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void restart(){
        Debug.Log("Restart");
        Main.ResetPlayer();
        resume();
    }

    public void Menu(){
        SceneManager.LoadScene(0);
        resume();
        Cursor.visible = true;
    }
}
