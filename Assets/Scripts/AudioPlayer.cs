using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if(FindObjectsOfType<AudioPlayer>().Length > 1)
        {
            Destroy(gameObject);
        }

    }
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
