/**
 * Super Pong game created by NAKNAMU, 01/2021
**/

using UnityEngine;

public class Menu : MonoBehaviour
{
    void Start()
    {
        SceneChanger.sceneHistory.Add("Menu");
    }

    public void StartGame()
    {
        SceneChanger.LoadScene("SelectPlayer");
    }

    public void LoadOptions()
    {
        SceneChanger.LoadScene("Options");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

}
