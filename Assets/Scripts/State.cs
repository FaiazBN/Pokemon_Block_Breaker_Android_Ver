using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]

public class State : ScriptableObject
{
    [TextArea(14,10)][SerializeField] string storyText;
    [SerializeField] State[] nextState;

    public string GetStoryState()
    {
        return storyText;
    }  
    public State[] GetNextState()
    {
        return nextState;
    }



}

