using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    AudioSource bonusSound;
    void Start()
    {
        bonusSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.name == "Ball")
        {
            string wallName = transform.name;

            if (Options.muteSounds == true)
            {
                bonusSound.Stop();
            }
            else
            {
                bonusSound.Play();
            }

            Score.playerScore(wallName);
            GameOverMenu.GameOver();
            collisionInfo.gameObject.SendMessage("ResetBall");

        }
    }
}
