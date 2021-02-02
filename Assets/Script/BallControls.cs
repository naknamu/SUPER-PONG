/**
 *This script handles all the ball's movement and how it interact with the paddle.
**/


using UnityEngine;
using UnityEngine.UI;

public class BallControls : MonoBehaviour
{
    public static float ballSpeed;

    #region
    private Rigidbody2D rigidBody;
    private TrailRenderer trailEffect;
    private ParticleSystem explode;
    private AudioSource clickSound;
    #endregion

    void Start()
    {
        //Initialize all the components in Start function
        rigidBody = GetComponent<Rigidbody2D>();
        clickSound = GetComponent<AudioSource>();
        trailEffect = GetComponent<TrailRenderer>();
        explode = GetComponent<ParticleSystem>();

        //The user can enable or disable the trail effect
        //in the options menu
        if (Options.ballTrailEffect)
        {
            trailEffect.enabled = true;
        }
        else
        {
            trailEffect.enabled = false;
        }

        //ball speed changes in three level's of game difficulty
        if (AILevel.isEasy)
        {
            ballSpeed = 10f;    //default speed of ball
            //Debug.Log("EASY=" + AILevel.isEasy);
        }
        else if (AILevel.isNormal)
        {
            ballSpeed = 15f;    //increase ball speed in normal mode
            //Debug.Log("NORMAL=" + AILevel.isNormal);

        }
        else if (AILevel.isHard)
        {
            ballSpeed = 20f;    //increase ball speed in hard mode
            //Debug.Log("HARD="+AILevel.isHard);
        }
        else
        {
            ballSpeed = Options.speedSliderOptions;    //ball's speed set in Settings
            //Debug.Log("DEFAULT");
        }
        
        //Debug.Log(ballSpeed);
        //call function to move ball with a delay of 2seconds
        Invoke("goBall", 2f);

    }

    //function that is called from SideWalls.cs
    //it resets the velocity, position and speed of the ball
    //also calls again the goBall function
    void ResetBall()
    {
        //reset velocity of the ball
        rigidBody.velocity = Vector2.zero;
        //reset position of the ball
        transform.position = Vector2.zero;

        //ball speed changes in three level's of game difficulty
        if (AILevel.isEasy)
        {
            ballSpeed = 10f;    //default speed of ball
        }
        else if (AILevel.isNormal)
        {
            ballSpeed = 15f;    //increase ball speed in normal mode

        }
        else if (AILevel.isHard)
        {
            ballSpeed = 20f;    //increase ball speed in hard mode
        }
        else
        {
            ballSpeed = Options.speedSliderOptions;    //ball's speed set in Settings
        }

        //call goBall function with 1s delay
        Invoke("goBall", 1);
    }

    //function that is called everytime tha ball collided with the paddle
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            //collisionInfo holds the collision information.
            //If the ball collided with the racket then:
            //collisionInfo.gameObject is the paddle
            //collisionInfo.transform.position is the paddle's position
            //collisionInfo.collider is the racket's collider

            //Ball hit the LEFT paddle?
            if (collisionInfo.gameObject.name == "Player" || collisionInfo.gameObject.name == "PlayerA")
            {
                //calculate hit factor
                float y = hitFactor(transform.position, collisionInfo.transform.position,
                    collisionInfo.collider.bounds.size.y);

                //calculate the direction, make length=1 via .normalized
                Vector2 dir = new Vector2(1, y).normalized;

                //Set the velocity with dir * speed
                GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
            }
            //Ball hit the Right paddle?
            if (collisionInfo.gameObject.name == "AI" || collisionInfo.gameObject.name == "PlayerB")
            {
                //calculate hit factor
                float y = hitFactor(transform.position, collisionInfo.transform.position,
                    collisionInfo.collider.bounds.size.y);

                //calculate the direction, make length=1 via .normalized
                Vector2 dir = new Vector2(-1, y).normalized;

                //Set the velocity with dir * speed
                GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
            }

            //increase ball speed over time
            ballSpeed += ballSpeed * Time.deltaTime;
            //Debug.Log(ballSpeed);

            //ball's particle effect is enabled upon collision with paddle
            //The user can enable or disable the ball's particle effect in Options menu
            if (Options.ballParticleEffect)
            {
                explode.Play();
            }
            else
            {
                explode.Pause();
            }

            //play audio upon ball-paddle collision
            //The user can enable or disable the ball-paddle sound collision in options menu
            if (Options.muteSounds == true)
            {
                clickSound.Stop();
            }
            else
            {
                clickSound.pitch = Random.Range(0.8f, 1.2f);    //the pitch varies every ball-paddle collision
                clickSound.Play();
            }
        }
    }

    //function that enables the ball to move during the start of the game
    void goBall()
    {

        float randomNumber = Random.Range(0, 2); //random number between 0 and 1

        if (randomNumber == 0)
        {
            rigidBody.AddForce(new Vector2(-50, -10)); //move ball left
        }
        else
        {
            rigidBody.AddForce(new Vector2(50, 10)); //move ball right
        }
        
    }

    //function that will return the yposition of the ball relative to the paddle
    public float hitFactor(Vector2 ballPos, Vector2 paddlePos, float racketHeight)
    {
        // || 1 <- at the top of racket
        // || 0 <- at the middle of the racket
        // ||-1 <- at the bottom of the racket
        return (ballPos.y - paddlePos.y) / racketHeight;
    }

}
