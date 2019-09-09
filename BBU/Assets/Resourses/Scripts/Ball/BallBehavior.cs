using System;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Vector2 firstPosition;
    private Vector2 lastPosition;
    private float dragDistance;

    private BallManager ballManager;
    private GameManager gameManager;
    private Rigidbody2D ballBody;
    private Vector3 newScale;

    private int RL;
    private float veloY;

    [HideInInspector]
    public int damage = 1;
    public float jumpForce;
    public float jumpWidth;
    public float plungeSpeed;
    public float multiplier;
    public float scaleSpeed;


    private void Start()
    {
        ballBody = GetComponent<Rigidbody2D>();

        // Set drag distance swipe
        dragDistance = Screen.height * 5 / 100;

        // Get direction ball
        ballManager = GameObject.Find("Ball").GetComponent<BallManager>();
        RL = -ballManager.RandomRL;

        // Get GameManager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        // Handle native touch events
        foreach (Touch touch in Input.touches)
        {
            HandleTouch(touch.fingerId, touch.position, touch.phase);
        }

        // Simulate touch events from mouse events
        if (Input.touchCount == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                HandleTouch(10, Input.mousePosition, TouchPhase.Began);
            }
            if (Input.GetMouseButton(0))
            {
                HandleTouch(10, Input.mousePosition, TouchPhase.Moved);
            }
            if (Input.GetMouseButtonUp(0))
            {
                HandleTouch(10, Input.mousePosition, TouchPhase.Ended);
            }
        }

        veloY = Math.Abs(ballBody.velocity.y);
        newScale = new Vector3(0.5f, 0.5f + veloY * multiplier, 0);
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, scaleSpeed * Time.deltaTime);
    }

    private void HandleTouch(int touchFingerId, Vector2 touchPosition, TouchPhase touchPhase)
    {
        switch (touchPhase)
        {
            case TouchPhase.Began:
                {
                    firstPosition = touchPosition;
                    lastPosition = touchPosition;
                    break;
                }
            case TouchPhase.Moved:
                {
                    lastPosition = touchPosition;
                    break;
                }
            case TouchPhase.Ended:
                {
                    
                    lastPosition = touchPosition;
                    if ((Mathf.Abs(lastPosition.x - firstPosition.x) > dragDistance || Mathf.Abs(lastPosition.y - firstPosition.y) > dragDistance)
                        && lastPosition.y < firstPosition.y)
                    {
                        float DeltaX = lastPosition.x - firstPosition.x;
                        float DeltaY = Mathf.Abs(lastPosition.y - firstPosition.y);
                        Vector2 plunge = new Vector2(plungeSpeed * DeltaX/DeltaY, -plungeSpeed);
                        ballBody.velocity = plunge;
                    }
                    else
                    {
                        ballBody.velocity = new Vector2(jumpWidth * RL, 0);
                        ballBody.AddForce(transform.up * jumpForce, ForceMode2D.Force);
                    }
                    break;
                }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "LeftWall")
        {
            RL = Mathf.Abs(RL);
        }
        if (collision.collider.name == "RightWall")
        {
            RL = -Mathf.Abs(RL);
        }
        if (collision.collider.name == "Ground")
        {
            gameManager.GameOver(); 
        }

    }
}
