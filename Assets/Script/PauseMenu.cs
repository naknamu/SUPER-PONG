using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);   //disables the pause panel
        Time.timeScale = 1f;
        GameManager.Music.pitch = 1f;
    }

    public void Pause()
    {
        gameIsPaused = true;
        pauseMenuUI.SetActive(true);   //enables the pause panel
        Time.timeScale = 0f;           //freezes the tie
        GameManager.Music.pitch = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;            //set back the time to normal scale
        SceneManager.LoadScene("Menu"); //loads menu scene
        Score.playeraScore = 0;         //
        Score.playerbScore = 0;         //resets the score
    }

    public void Options()
    {
        SceneChanger.LoadScene("Options");
    }

    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    //disables play mode in unity editor
        #else
        Application.Quit();
        #endif
    }
}
