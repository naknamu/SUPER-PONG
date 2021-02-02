/**
 *This script contains the three levels of the game's difficulty.
 *It is only applicable in 1 Player mode.
 *The three levels are Easy, Normal and Hard.
 *The three variables that are modified in each difficulty are 
 *the paddle's speed of the player, the AI paddle speed and the lerpSpeed.
**/

using UnityEngine;

public class AILevel : MonoBehaviour
{
    public static bool isEasy;
    public static bool isNormal;
    public static bool isHard;

    public void Easy()
    {
        isEasy = true;
        isNormal = false;
        isHard = false;
        PlayerControls.playerSpeed = 10f;
        PlayerControls.lerpSpeed = 1f;
        PlayerControls.AIspeed = 10f;
        SceneChanger.LoadScene("SelectGoals");
    }

    public void Normal()
    {
        isEasy = false;
        isNormal = true;
        isHard = false;
        PlayerControls.playerSpeed = 15f;
        PlayerControls.lerpSpeed = 3f;
        PlayerControls.AIspeed = 15f;
        SceneChanger.LoadScene("SelectGoals");
    }

    public void Hard()
    {
        isEasy = false;
        isNormal = false;
        isHard = true;
        PlayerControls.playerSpeed = 15f;
        PlayerControls.lerpSpeed = 5f;
        PlayerControls.AIspeed = 15f;
        SceneChanger.LoadScene("SelectGoals");
    }

    public void Back()
    {
        SceneChanger.PreviousScene();
    }
}
