using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData : MonoBehaviour
{
    public DialogueData(string dialogue, Sprite portrait) 
    {
        Dialogue = dialogue;
        Portrait = portrait;
    }

    public string Dialogue { get; set; }
    public Sprite Portrait { get; set; }
}
