using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public static bool gameEnded = false;
    public GameObject gameOverMenuUI;

    #region
    private GameObject newGO;
    private GameObject newGO1;
    private GameObject newGO2;
    private Font pixelfjverdana;
    private static Text myText;
    private static Text myText1;
    private static Text myText2;
    #endregion

    void Start()
    {
        pixelfjverdana = Resources.Load("PixelFJVerdana12pt") as Font;

        newGO = new GameObject("winnerText");
        newGO1 = new GameObject("firstSide");
        newGO2 = new GameObject("secondSide");

        newGO.transform.SetParent(gameOverMenuUI.transform);
        newGO1.transform.SetParent(gameOverMenuUI.transform);
        newGO2.transform.SetParent(gameOverMenuUI.transform);

        myText = newGO.AddComponent<Text>();
        myText1 = newGO1.AddComponent<Text>();
        myText2 = newGO2.AddComponent<Text>();

        myText.font = pixelfjverdana;
        myText.fontSize = 32;
        myText.alignment = TextAnchor.MiddleCenter;

        myText1.font = pixelfjverdana;
        myText1.fontSize = 28;
        myText1.alignment = TextAnchor.MiddleCenter;

        myText2.font = pixelfjverdana;
        myText2.fontSize = 28;
        myText2.alignment = TextAnchor.MiddleCenter;


        RectTransform rectTransform = myText.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-1, -127, 0);
        rectTransform.sizeDelta = new Vector2(546, 157);

        RectTransform rectTransform1 = myText1.GetComponent<RectTransform>();
        rectTransform1.localPosition = new Vector3(-313, 0, 0);
        rectTransform1.sizeDelta = new Vector2(307, 126);
        //rectTransform1.Rotate(new Vector3(0, 0, -90));

        RectTransform rectTransform2 = myText2.GetComponent<RectTransform>();
        rectTransform2.localPosition = new Vector3(313, 0, 0);
        rectTransform2.sizeDelta = new Vector2(307, 126);
        //rectTransform1.Rotate(new Vector3(0, 0, 90));
    }

    void Update()
    {
        if (gameEnded == true)
        {
            Pause();
        }
    }

    public static void GameOver()
    {
        //Player vs AI
        //5 GOALS
        if (Score.playeraScore == 5 && PlayerMenu.playerOne == true && PlayerGoals.numberOfGoals == 5)
        {
            gameEnded = true;
            myText.text = "YOU WIN !!! :) Congratulations!";

        }
        else if (Score.playerbScore == 5 && PlayerMenu.playerOne == true && PlayerGoals.numberOfGoals == 5)
        {
            gameEnded = true;
            myText.text = "AI Win! You Lose!";
        }
        //10 GOALS
        if (Score.playeraScore == 10 && PlayerMenu.playerOne == true && PlayerGoals.numberOfGoals == 10)
        {
            gameEnded = true;
            myText.text = "YOU WIN !!! :) Congratulations!";
        }
        else if (Score.playerbScore == 10 && PlayerMenu.playerOne == true && PlayerGoals.numberOfGoals == 10)
        {
            gameEnded = true;
            myText.text = "AI Win! You Lose!";
        }
        //15 GOALS
        if (Score.playeraScore == 15 && PlayerMenu.playerOne == true && PlayerGoals.numberOfGoals == 15)
        {
            gameEnded = true;
            myText.text = "YOU WIN !!! :) Congratulations!";
        }
        else if (Score.playerbScore == 15 && PlayerMenu.playerOne == true && PlayerGoals.numberOfGoals == 15)
        {
            gameEnded = true;
            myText.text = "AI Win! You Lose!";
        }

        //Player 1 vs Player 2
        //5 GOALS
        if (Score.playeraScore == 5 && PlayerMenu.playerOne == false && PlayerGoals.numberOfGoals == 5)
        {
            //Player 1 Wins
            gameEnded = true;
            myText1.text = "You Win!!!";
            myText2.text = "You Lose...";
        }
        else if (Score.playerbScore == 5 && PlayerMenu.playerOne == false && PlayerGoals.numberOfGoals == 5)
        {
            //Player 2 Wins
            gameEnded = true;
            myText1.text = "You Lose...";
            myText2.text = "You Win!!!";
        }
        //10 GOALS
        if (Score.playeraScore == 10 && PlayerMenu.playerOne == false && PlayerGoals.numberOfGoals == 10)
        {
            //Player 1 Wins
            gameEnded = true;
            myText1.text = "You Win!!!";
            myText2.text = "You Lose...";
        }
        else if (Score.playerbScore == 10 && PlayerMenu.playerOne == false && PlayerGoals.numberOfGoals == 10)
        {
            //Player 2 Wins
            gameEnded = true;
            myText1.text = "You Lose...";
            myText2.text = "You Win!!!";
        }
        //15 GOALS
        if (Score.playeraScore == 15 && PlayerMenu.playerOne == false && PlayerGoals.numberOfGoals == 15)
        {
            //Player 1 Wins
            gameEnded = true;
            myText1.text = "You Win!!!";
            myText2.text = "You Lose...";
        }
        else if (Score.playerbScore == 15 && PlayerMenu.playerOne == false && PlayerGoals.numberOfGoals == 15)
        {
            //Player 2 Wins
            gameEnded = true;
            myText1.text = "You Lose...";
            myText2.text = "You Win!!!";
        }

    }

    public void Restart()
    {
        gameEnded = false;
        gameOverMenuUI.SetActive(false);   //disables the pause panel
        Time.timeScale = 1f;
        Score.playeraScore = 0;            //resets the score
        Score.playerbScore = 0;            //
        GameManager.Music.pitch = 1f;
    }

    public void Pause()
    {
        gameEnded = true;
        gameOverMenuUI.SetActive(true);   //enables the pause panel
        Time.timeScale = 0f;              //freezes the tie
        GameManager.Music.pitch = 0f;     //stops the music
    }

    public void LoadMenu()
    {
        gameEnded = false;
        Time.timeScale = 1f;            //set back the time to normal scale
        SceneManager.LoadScene("Menu"); //loads menu scene
        Score.playeraScore = 0;         //
        Score.playerbScore = 0;         //resets the score

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
