using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    void Start()
    {
        DialogueManager.AddDialogue("Hello World!", null);
        DialogueManager.AddDialogue("Hello Sunshine!", null);
        DialogueManager.AddDialogue("Hello Everyone!", null);
    }
}
