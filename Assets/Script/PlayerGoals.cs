using UnityEngine;

public class PlayerGoals : MonoBehaviour
{
    public static int numberOfGoals;

    public void FiveGoals()
    {
        numberOfGoals = 5;
        LoadPlayerTypeScene();
    }

    public void TenGoals()
    {
        numberOfGoals = 10;
        LoadPlayerTypeScene();
    }

    public void FifteenGoals()
    {
        numberOfGoals = 15;
        LoadPlayerTypeScene();
    }

    void LoadPlayerTypeScene()
    {
        if (PlayerMenu.playerOne == true)
        {
            SceneChanger.LoadScene("1Player");
        }
        else
        {
            SceneChanger.LoadScene("2Players");
        }
    }

    public void Back()
    {
        SceneChanger.PreviousScene();
    }
}
