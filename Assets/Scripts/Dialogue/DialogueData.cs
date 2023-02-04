using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData : MonoBehaviour
{
    public DialogueData(string dialogue, Sprite portrait) 
    {
        Dialogue = dialogue;
        Portrait = portrait;
        Hold = 1f;
    }
    public DialogueData(string dialogue, Sprite portrait, float hold)
    {
        Dialogue = dialogue;
        Portrait = portrait;
        Hold = hold;
    }

    public string Dialogue { get; set; }
    public Sprite Portrait { get; set; }

    public float Hold { get; set; }
}
