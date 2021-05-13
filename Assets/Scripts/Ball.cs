using UnityEngine;

public class Ball : MonoBehaviour
{
    // config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] BallBounceAudio;
    [SerializeField] float randomFactor;
    [SerializeField] AudioClip[] startClips;

    //states
    Vector2 PaddletoBallVector;
    bool hasStarted = false;

    // Cached
    AudioSource myAudio;
    Rigidbody2D ballLaunch;
    Vector2 velocityTweak;
    Lives lives;

    void Start()
    {
        PaddletoBallVector = transform.position - paddle1.transform.position;
        myAudio =  GetComponent<AudioSource>();
        ballLaunch = GetComponent<Rigidbody2D>();
        lives = FindObjectOfType<Lives>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!hasStarted)
        {
            LockBallToPaddle(); /// watch the lecture 55
            //LaunchonMouseClick();
        }
        else if (lives.ReturnBackBall())
        {
            //LockBallToPaddle();
            hasStarted = false;
        }

    }


    public void LaunchonMouseClick()
    {
        //if (ButtonClickShoot())
        //{
        if (!hasStarted)
        {
            hasStarted = true;
            ballLaunch.velocity = new Vector2(xPush, yPush);
            StartAudio();
        }
        //}
    }

    private void StartAudio()
    {
        AudioClip startClip = startClips[Random.Range(0, startClips.Length)];
        myAudio.PlayOneShot(startClip);
    }

    public bool HasStarted()
    {
        return hasStarted;
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + PaddletoBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Vector2 velocityTweak = new Vector2(ballLaunch.velocity.x + Random.Range(-randomFactor, randomFactor),
                                    // ballLaunch.velocity.y + Random.Range(-randomFactor, randomFactor));
        float randomAngle = Random.Range(-randomFactor, randomFactor);


        if (hasStarted)
        {
            PlayAudioOnCollision();
            //ballLaunch.velocity = velocityTweak.normalized * ballLaunch.velocity.magnitude;
            ballLaunch.velocity = Quaternion.Euler(0, 0, randomAngle) * ballLaunch.velocity;

        }

        // alternate (applied)
        //float randomAngle = Random.Range(-randomFactor, randomFactor);
       // ballLaunch.velocity = Quaternion.Euler(0, 0, randomAngle) * ballLaunch.velocity;

    }

    private void PlayAudioOnCollision()
    {
        AudioClip BallClip = BallBounceAudio[Random.Range(0, BallBounceAudio.Length)];
        myAudio.PlayOneShot(BallClip);
    }

    public void ResetBallPosition()
    {
        LockBallToPaddle();
       hasStarted = false;

    }
}
