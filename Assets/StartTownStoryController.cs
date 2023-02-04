using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartTownStoryController : MonoBehaviour
{
    [SerializeField] PlayerController_Rick playerController;

    float dialogTimer = 1.0f;
    int dialogCount = 0;
    int maxDialogs = 3;

    [SerializeField] List<CinematicDialogElements> cinematicDialogElements = new List<CinematicDialogElements>();

    [SerializeField] bool dialogOnStart = false;
	[SerializeField] bool pausePlayer = true; //Since you said I could reverse engineer and adds stuff, I'm just putting this bool here. It helps add some options for gameplay since dialog is automatic anyways. - N
	bool dialogRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        if (dialogOnStart)
        {
            TriggerCinematicEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogRunning) return;

        dialogTimer -= Time.deltaTime;
        if(dialogTimer < 0)
        {
            if(dialogCount >= cinematicDialogElements.Count)
            {
                playerController.EnableController();
            } else
            {
                NextDialogElement();
            }
        }
    }

    void NextDialogElement()
    {
        dialogTimer = cinematicDialogElements[dialogCount].duration;
        DialogueManager.AddDialogue(cinematicDialogElements[dialogCount].text, cinematicDialogElements[dialogCount].portrait);
        dialogCount++;
    }

    public void TriggerCinematicEvent()
    {
		if (pausePlayer) playerController.DisableController();
        NextDialogElement();
        dialogRunning = true;
    }
}

[Serializable]
public class CinematicDialogElements
{
    public string text = "";
    public Sprite portrait = null;
    public float duration = 0;
}
