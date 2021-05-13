using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDestroyer : MonoBehaviour
{
    //Cached

    AudioPlayerLV audioPlayerLV;
    void Start()
    {
        audioPlayerLV = FindObjectOfType<AudioPlayerLV>();
        if (FindObjectsOfType<AudioPlayerLV>().Length > 0)
        {
            audioPlayerLV.DestroyMe();
        }
    }


}
