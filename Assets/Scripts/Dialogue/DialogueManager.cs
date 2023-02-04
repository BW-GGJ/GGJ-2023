using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    private static List<DialogueData> DialogueDatas = new List<DialogueData>();
    [SerializeField] private float LetterSleep;
    [SerializeField] private float BigSleep = 1f;

    [SerializeField] private TMP_Text DialogueBox;
    [SerializeField] private Image Portrait;
    [SerializeField] private GameObject Character, Dialogue;

    private bool isSkip, isPlaying, isAuto;

    private bool isActive = true;

    private void Awake()
    {
        if(!instance) instance = this;
    }

    public static void AddDialogue(DialogueData data) 
    {
        DialogueDatas.Add(data);
    }

    public static void AddDialogue(string Dialogue, Sprite Portrait) 
    {
        DialogueDatas.Add(new DialogueData(Dialogue, Portrait));
    }
    public static void AddDialogue(string Dialogue, Sprite Portrait, float hold)
    {
        DialogueDatas.Add(new DialogueData(Dialogue, Portrait, hold));
    }
    public void SetActive(bool Active)
    {
        Character.SetActive(Active);
        Dialogue.SetActive(Active);
    }
    public void SetAuto(bool Auto) 
    {
        isAuto = Auto;
    }

    private void Start()
    {
        if(DialogueDatas.Count > 0) StartCoroutine(AdvanceText());
        isAuto = true;
        SetActive(false);
    }

    private void Update()
    {
        if (isAuto) 
        {
            if (isPlaying || DialogueDatas.Count == 0) 
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                isSkip = true;
            }

            StartCoroutine(AdvanceText());
            return;
        }

        if (Input.GetKeyDown(KeyCode.Z) && !isPlaying) 
        {
            StartCoroutine(AdvanceText());
        }
        else if (Input.GetKeyDown(KeyCode.Z)) 
        {
            isSkip = true;
        }
    }

    private IEnumerator AdvanceText()
    {
        SetActive(true);

        if (DialogueDatas.Count <= 0) 
        {
            yield break;
        }

        isPlaying = true;
        string text = DialogueDatas[0].Dialogue;
        Portrait.sprite = DialogueDatas[0].Portrait;

        DialogueBox.text = text;
        DialogueBox.maxVisibleCharacters = 0;
        yield return new WaitForSeconds(LetterSleep);

        foreach (char c in text) 
        {
            //TMP, visible increase
            DialogueBox.maxVisibleCharacters++;

            if (c.ToString().ToLower() == "a" || c.ToString().ToLower() == "e" || c.ToString().ToLower() == "i" || c.ToString().ToLower() == "o" || c.ToString().ToLower() == "u") 
            {
                AudioManager.instance.PlayVocalBop(16, 22);
            }

            //Sleeps if not interrupted
            if(!isSkip) yield return new WaitForSeconds(LetterSleep);
        }
        if (isAuto) 
        {
            if (DialogueDatas[0].Hold != 1f)
            {
                yield return new WaitForSeconds(DialogueDatas[0].Hold);
            }
            else
            {
                yield return new WaitForSeconds(BigSleep);
            }
        }
        isSkip = false;
        isPlaying = false;

        DialogueDatas.RemoveAt(0);

        if (DialogueDatas.Count <= 0)
        {
            DialogueBox.maxVisibleCharacters = 0;

            SetActive(false);
            yield break;
        }
    }
}
