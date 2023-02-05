using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetuEncounterController : MonoBehaviour
{
    bool wasTriggered = false;
    [SerializeField] bool disablesPlayer = true;

    [SerializeField] KetuController ketu;
    [SerializeField] PlayerController_Rick playerController;
    [SerializeField] List<CinematicDialogElements> cinematicDialogElements = new List<CinematicDialogElements>();

    int dialogCount = 0;
    float dialogTimer = 1.0f;
    bool dialogRunning = false;

    public static bool isFinished;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    void NextDialogElement()
    {
        dialogTimer = cinematicDialogElements[dialogCount].duration;
        DialogueManager.AddDialogue(cinematicDialogElements[dialogCount].text, cinematicDialogElements[dialogCount].portrait);
        dialogCount++;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
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
