using UnityEngine;

public class PlayerMenu : MonoBehaviour
{

    public static bool playerOne = false;

    public void OnePlayer()
    {
        playerOne = true;
        SceneChanger.LoadScene("SelectDifficulty");
    }

    public void TwoPlayer()
    {
        playerOne = false;
        AILevel.isEasy = false;
        AILevel.isNormal = false;
        AILevel.isHard = false;
        SceneChanger.LoadScene("SelectGoals");
    }

    public void Back()
    {
        SceneChanger.PreviousScene();
    }


}
