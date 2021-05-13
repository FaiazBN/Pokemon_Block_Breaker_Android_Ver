using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ConversationPart : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] State startingState;
    [SerializeField] AudioClip audioClip;

    State state;
    SceneLoader sceneLoader;
    AudioSource audioSource;
    AudioPlayer audioPlayer;

    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStoryState();
        sceneLoader = FindObjectOfType<SceneLoader>();
        audioSource = GetComponent<AudioSource>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        audioPlayer.DestroyMe();
    }
    
    void Update()
    {
        //ManangeStates();
    }
    private IEnumerator WaitForSceneLoad()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        yield return new WaitForSeconds(0.45f);
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
    public void ManangeStates()
    {
        var nextStates = state.GetNextState();

       // for (int i = 0; i < nextStates.Length; i++) {

            if (state.GetNextState().Length > 0)
            {
                //if (Input.GetKeyDown(KeyCode.Return))
               // {
                     state = nextStates[0];
                     audioSource.PlayOneShot(audioClip);
                //}
            }
            else if(state.GetNextState().Length <= 0)
            {
                //if (Input.GetKeyDown(KeyCode.Return))
                //{
                //sceneLoader.LoadNextScene();
                audioSource.PlayOneShot(audioClip);
                StartCoroutine(WaitForSceneLoad());
            //}
            }
        //}
        
        textComponent.text = state.GetStoryState();
    }
}
