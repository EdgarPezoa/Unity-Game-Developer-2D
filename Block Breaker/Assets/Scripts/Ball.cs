using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Paddle paddle;
    [SerializeField] private float xVelocity = 2f;
    [SerializeField] private float yVelocity = 10f;
    [SerializeField] private AudioClip[] blockSounds;
    [SerializeField] private AudioClip paddleSound;

    private CircleCollider2D myCollider2D;
    private AudioSource audioSource;
    private GameSession gameStatus;
    private Vector2 ballPos;
    private Rigidbody2D myRigidbody2D;
    private bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myCollider2D = GetComponent<CircleCollider2D>();
        gameStatus = FindObjectOfType<GameSession>();
        ballPos = new Vector2(paddle.transform.position.x, (paddle.transform.position.y + 1f));
        isStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStarted)
        {
            LaunchBall();
            LockToPaddle();
        }
        
    }

    void LockToPaddle() {
        float xPos = paddle.transform.position.x;
        ballPos.x = xPos;
        transform.position = ballPos;
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0)){
            myRigidbody2D.velocity = new Vector2(xVelocity, yVelocity);
            isStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isStarted){
            switch (collision.gameObject.tag){
                case "Paddle": {
                    audioSource.PlayOneShot(paddleSound);
                    gameStatus.ResetMultiple();
                    break;
                }
                default: {
                    audioSource.PlayOneShot( getRandomBlockAudio() );
                    break;
                }
            }
        }
    }

    private AudioClip getRandomBlockAudio()
    {
        return blockSounds[ Random.Range(0, blockSounds.Length)];
    }
}
