using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetuEncounterController : MonoBehaviour
{
    bool wasTriggered = false;
    [SerializeField] bool disablesPlayer = true;

    [SerializeField] protected KetuController ketu;
    [SerializeField] protected PlayerController_Rick playerController;
    [SerializeField] protected List<CinematicDialogElements> cinematicDialogElements = new List<CinematicDialogElements>();

    protected int dialogCount = 0;
    float dialogTimer = 1.0f;
    bool dialogRunning = false;

    public static bool isFinished;

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        if (!dialogRunning) return;

        dialogTimer -= Time.deltaTime;
        if (dialogTimer < 0)
        {
            if (dialogCount >= cinematicDialogElements.Count)
            {
                if (disablesPlayer) playerController.EnableController();
                ketu.BeginKetuDespawnSequence();
                dialogRunning = false;
                isFinished = true;
            }
            else
            {
                NextDialogElement();
            }
        }
    }

    public virtual void NextDialogElement()
    {
        dialogTimer = cinematicDialogElements[dialogCount].duration;
        DialogueManager.AddDialogue(cinematicDialogElements[dialogCount].text, cinematicDialogElements[dialogCount].portrait);
        dialogCount++;
    }



    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !wasTriggered)
        {
            isFinished = false;
            wasTriggered = true;
            ketu.BeginKetuSpawnSequence();
            if(disablesPlayer) playerController.DisableController();
            dialogRunning = true;
        }
    }
}
