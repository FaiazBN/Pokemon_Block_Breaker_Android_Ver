using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void LoadPrevScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex - 1);

    }
    public void ResetSystem()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadAboutScene()
    {
        SceneManager.LoadScene("About Scene");
    }
    public void LoadInstructionScene()
    {
        SceneManager.LoadScene("Instruction Scene");
    }
    public void LoadLevelsScene()
    {
        SceneManager.LoadScene("Levels Scene");
    }
    public void LoadFirstLevel() 
    {
        SceneManager.LoadScene(4);
    }
    public void LoadAdditionalLevelScene()
    {
        SceneManager.LoadScene(24);
    }
    public void LoadEndCreditSceneScene()
    {
        SceneManager.LoadScene(19);
    }

}
