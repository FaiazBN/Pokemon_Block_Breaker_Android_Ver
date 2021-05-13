using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{


    /// config params
    [SerializeField] int pointsPerBlocksDestroyed = 10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayOn;


    /// state vars
    [SerializeField] int currentScore = 0;

    public void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;   /// FindObject(s)OfType
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        scoreText.text = currentScore.ToString();

    }
    public void AddToScore()
    {
        currentScore += pointsPerBlocksDestroyed;
        
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayOn()
    {
        return isAutoPlayOn;
    }

    public void ControlTime()
    {
       /*
         bool wasPressed = false; // Not in update
           if (Input.GetKeyDown(KeyCode.Space) && !wasPressed)
            {
                Time.timeScale = 0.2f;
                wasPressed = true;
                Debug.Log("Wow I was pressed");

             }
         else if (Input.GetKeyDown(KeyCode.Space) && wasPressed)
          {
               Time.timeScale = 1f;
               wasPressed = false;
               Debug.Log("Wow I was pressed twice");
           }

        */

    }
}
