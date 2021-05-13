using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{

    [Range(0.1f, 10f)][SerializeField] float gameSpeed;

    void Update()
    {
        Time.timeScale = gameSpeed;

    }
}
