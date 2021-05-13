using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAfterDelay : MonoBehaviour
{
    [SerializeField] private float timeAfterLoad = 10f;
    [SerializeField] private string sceneToLoad;
    private float timeElapsed;

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > timeAfterLoad)
            SceneManager.LoadScene(sceneToLoad);
        
    }
}
