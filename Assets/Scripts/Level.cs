using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // config params
    [SerializeField] private int blockCount;

    // cached
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        blockCount++;
    }
    public void DestroyedBlock()
    {
        blockCount--;
        if(blockCount  <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
 
}
