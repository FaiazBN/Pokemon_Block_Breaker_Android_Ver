using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lives : MonoBehaviour
{
    //config params
    [SerializeField] GameObject[] livesSprite;
    [SerializeField] AudioClip looseLife;
    [SerializeField] GameObject blockParticle;
    [SerializeField] GameObject[] recallSprite;
    [SerializeField] int totalRecall;
    [SerializeField] AudioClip noRecallAudio;
    [SerializeField] AudioClip RecallAudio;
    //states
    [SerializeField] int totalLives = 3;
    [SerializeField] bool backBall = false;
    //cached
    AudioSource myAudio;
    Ball myBall;
    AudioPlayer audioPlayer;


    void Start()
    {
        myBall = FindObjectOfType<Ball>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        myAudio = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().buildIndex > 2)
        {
            audioPlayer.DestroyMe();
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!myBall.HasStarted())
        {
            backBall = false;
            ReturnBackBall();
        }
        //LockBallToPaddle();
        /* 
         * PC version
         * if (totalRecall != 0)
        {
            BackBall();
        }
        else
        {

            backBall = false;
            if (Input.GetKeyDown(KeyCode.F))
            {
                myAudio.PlayOneShot(noRecallAudio);
            }
        }
        */
    }
    /*public void BackBall()
     * 
     * pc version
    {

       if (Input.GetKeyDown(KeyCode.F))
        {
        totalRecall--;
        Destroy(recallSprite[totalRecall]);
        myAudio.PlayOneShot(RecallAudio);
        backBall = true;
        ReturnBackBall();

        }
            else
            {
                backBall = false;
                ReturnBackBall();
            }
        
    }
    */
    public void BackBall()
    {

        if (totalRecall >= 0)
        {
            totalRecall--;
            Destroy(recallSprite[totalRecall]);
            myAudio.PlayOneShot(RecallAudio);
            backBall = true;
            ReturnBackBall();

        }
        else
        {
            myAudio.PlayOneShot(noRecallAudio);
            backBall = false;
            ReturnBackBall();
        }

    }
    public bool ReturnBackBall()
    {
        return backBall;
    }
    public void ChanceCounter()
    {
        AudioPlayer();
        ChanceController();

        myBall.ResetBallPosition();

    }

    private void ChanceController()
    {
        totalLives--;

        GameObject reducedLife = livesSprite[totalLives];
        Destroy(reducedLife);


        if (totalLives == 0)
        {
            SceneManager.LoadScene("End Game");
        }
    }

    private void AudioPlayer()
    {
        myAudio.PlayOneShot(looseLife);

    }

}
