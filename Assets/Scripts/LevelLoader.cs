using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public void LoadPrevScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex - 1);

    }
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(4);
    }
    public void LoadSecondLevel()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadThirdLevel()
    {
        SceneManager.LoadScene(6);
    }
    public void LoadFourthLevel()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadFifthLevel()
    {
        SceneManager.LoadScene(8);
    }
    public void LoadSixthLevel()
    {
        SceneManager.LoadScene(9);
    }
    public void LoadSeventhLevel()
    {
        SceneManager.LoadScene(10);
    }
    public void LoadEighthLevel()
    {
        SceneManager.LoadScene(11);
    }
    public void LoadNinethLevel()
    {
        SceneManager.LoadScene(12);
    }
    public void LoadTenthLevel()
    {
        SceneManager.LoadScene(13);
    }
    public void LoadEleventhLevel()
    {
        SceneManager.LoadScene(14);
    }
    public void LoadTwelvethLevel()
    {
        SceneManager.LoadScene(15);
    }
    public void LoadThirteenthLevel()
    {
        SceneManager.LoadScene(16);
    }
    public void LoadFouteenthLevel()
    {
        SceneManager.LoadScene(17);
    }
    public void LoadFifteenthLevel()
    {
        SceneManager.LoadScene(18);
    }

}
