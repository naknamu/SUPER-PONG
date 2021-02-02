using UnityEngine;

public class Score : MonoBehaviour
{
    public static int playeraScore = 0;
    public static int playerbScore = 0;

    public GUISkin theSkin;
    
    public static void playerScore (string wallName)
    {
        if (wallName == "rightWall")
        {
            playeraScore += 1;
        }
        else
        {
            playerbScore += 1;
        }
    }

    void OnGUI()
    {
        GUI.skin = theSkin;

        if (PlayerMenu.playerOne == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 260, 25, 120, 100), "Player: " + playeraScore);
            GUI.Label(new Rect(Screen.width / 2 + 150 - 12, 25, 60, 100), "AI: " + playerbScore);
        }
        else
        {
            GUI.Label(new Rect(Screen.width / 2 - 280, 25, 140, 100), "Player 1: " + playeraScore);
            GUI.Label(new Rect(Screen.width / 2 + 150 - 12, 25, 140, 100), "Player 2: " + playerbScore);
        }
    }

}
