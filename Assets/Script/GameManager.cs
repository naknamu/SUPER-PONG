/**
 * The script that handles all the boundaries/wall of the game.
 * The paddle's position are initialize here during the start of the game
 * and the background music is played
 **/


using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera mainCam;

    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D rightWall;
    public BoxCollider2D leftWall;

    public Transform playerA;
    public Transform playerB;

    public static AudioSource Music;
   
    void Start()
    {
        topWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width*2f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        bottomWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, -(mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f));

        rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height*2f, 0f)).y);
        rightWall.offset = new Vector2((mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x) + 0.5f, 0f);

        leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(-((mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x) + 0.5f), 0f);

        playerA.position.Set(mainCam.ScreenToWorldPoint(new Vector3(50f, 0f, 0f)).x, 0f, 0f);
        playerB.position.Set(mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 50f, 0f, 0f)).x, 0f, 0f);

        Music = GetComponent<AudioSource>();
        Music.Play();
        Music.volume = Options.volumeSliderOptions;
        //Debug.Log(Music.volume);
    }
    
}
