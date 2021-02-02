using UnityEngine;

public enum Owner
{
    Player,
    AI
}

public class PlayerControls : MonoBehaviour
{
    public Owner playerType;

    public KeyCode moveUp;
    public KeyCode moveDown;

    public static float playerSpeed = 10f;
    public static float AIspeed;
    public static float lerpSpeed;
    public float playerDragSpeed = 50f;

    public BallControls theBall;
    public Rigidbody2D AIrigidBody;

    private float limitY = 2.4f;
    private float playerposScreen = 6f;

    public Transform playerAtransform;
    public Transform playerBtransform;

    void Start()
    {
        AIrigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (playerType == Owner.Player)
        {
            //PlayerMovement();
            if (PlayerMenu.playerOne)
            {
                OneTouchControls();
            }
            else
            {
                multipleTouchControls();
            }
        }
        else if (playerType == Owner.AI)
        {
            AImovement();
        }
    }

    //function to move the player's paddle using keyboard
    //public void PlayerMovement()
    //{
    //    if (Input.GetKey(moveUp))
    //    {
    //        if (transform.position.y < limitY)
    //        {
    //            transform.position += Vector3.up * playerSpeed * Time.deltaTime;
    //        }
    //    }
    //    if (Input.GetKey(moveDown))
    //    {
    //        if (transform.position.y > -limitY)
    //        {
    //            transform.position += Vector3.down * playerSpeed * Time.deltaTime;
    //        }
    //    }
    //}

    //One Player touch control
    public void OneTouchControls()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Moved) //make sure paddle is dragged and not teleported anywhere
            {
                // get the touch position from the screen touch to world point
                Vector2 touchedPos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));

                touchedPos.x = -(playerposScreen);

                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                transform.position = Vector2.Lerp(transform.position, touchedPos, playerDragSpeed * Time.deltaTime);

                BoundPaddle();
            }
        }
    }

    //Two Players touch control
    public void multipleTouchControls()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                //initialize multiple touch
                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Moved) //make sure paddle is dragged and not teleported anywhere
                {
                    //get the touch position from the screen touch to world point
                    Vector2 touchedPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);

                    //touched from the LEFT SIDE?
                    if (touchedPos.x < 0)
                    {
                        Vector2 playerApos = touchedPos;
                        playerApos.x = -(playerposScreen);
                        if (playerApos.y > limitY)
                        {
                            playerApos.y = limitY;
                        }
                        else if (playerApos.y < (-limitY))
                        {
                            playerApos.y = -limitY;
                        }
                        playerApos = Vector2.Lerp(playerAtransform.position, playerApos, playerDragSpeed * Time.deltaTime);
                        playerAtransform.position = playerApos;
                    }
                    //touched from the RIGHT SIDE?
                    else
                    {
                        Vector2 playerBpos = touchedPos;
                        playerBpos.x = playerposScreen;
                        if (playerBpos.y > limitY)
                        {
                            playerBpos.y = limitY;
                        }
                        else if (playerBpos.y < (-limitY))
                        {
                            playerBpos.y = -limitY;
                        }
                        playerBpos = Vector2.Lerp(playerBtransform.position, playerBpos, playerDragSpeed * Time.deltaTime);
                        playerBtransform.position = playerBpos;
                    }
                }
            }
        }
    }

    //function to make the AI paddle follow the ball's y position
    public void AImovement()
    {
        ResetPaddle();

        if (theBall.transform.position.y > transform.position.y)
        {
            if (AIrigidBody.velocity.y < 0)
            {
                AIrigidBody.velocity = Vector2.zero;
            }

            AIrigidBody.velocity = Vector2.Lerp(AIrigidBody.velocity, Vector2.up * AIspeed, lerpSpeed * Time.deltaTime);

        }

        else if (theBall.transform.position.y < transform.position.y)
        {
            if (AIrigidBody.velocity.y > 0)
            {
                AIrigidBody.velocity = Vector2.zero;
            }

            AIrigidBody.velocity = Vector2.Lerp(AIrigidBody.velocity, Vector2.down * AIspeed, lerpSpeed * Time.deltaTime);
        }
        else
        {
            AIrigidBody.velocity = Vector2.Lerp(AIrigidBody.velocity, Vector2.zero * AIspeed, lerpSpeed * Time.deltaTime);
        }

        BoundPaddle();

    }

    //function to bound the paddle to camera boundary
    public void BoundPaddle()
    {
        Vector3 pos = transform.position;

        if (pos.y > limitY)
        {
            pos.y = limitY;
            AIrigidBody.velocity = Vector2.zero;
        }
        else if (pos.y < (-limitY))
        {
            pos.y = (-limitY);
            AIrigidBody.velocity = Vector2.zero;
        }
        transform.position = pos;
    }

    //reset paddle movement during ball reset
    public void ResetPaddle()
    {
        Vector3 pos = transform.position;

        if (theBall.transform.position.y == 0)
        {
            AIrigidBody.velocity = Vector2.zero;
            pos.y = 0;
        }
        transform.position = pos;
    }
}