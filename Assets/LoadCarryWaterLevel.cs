using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCarryWaterLevel : MonoBehaviour
{
    bool triggered = false;

    bool mapCollected = false;

    bool bouncingBack = false;
    float bouncebackTimer = 0.0f;
    float bouncebackTime = 4.0f;
    bool secondDialogTriggered = false;

    [SerializeField] PlayerController_Rick playerController;
    [SerializeField] List<CinematicDialogElements> bouncebackDialog = new List<CinematicDialogElements>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bouncingBack)
        {
            bouncebackTimer += Time.deltaTime;
            if(bouncebackTimer > 2)
            {
                if (!secondDialogTriggered)
                {
                    secondDialogTriggered = true;
                    DialogueManager.AddDialogue(bouncebackDialog[1].text, bouncebackDialog[1].portrait, bouncebackDialog[1].duration);
                } 
            }
            if(bouncebackTimer > bouncebackTime)
            {
                playerController.EnableController();
                bouncingBack = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if(bouncingBack && bouncebackTimer > 2 && bouncebackTimer < 3f)
        {
            playerController.gameObject.transform.Translate(0, 3 * Time.fixedDeltaTime, 0);
        }
    }
    public void CollectedMap()
    {
        mapCollected = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !triggered)
        {
            if (mapCollected)
            {
                triggered = true;
                SceneChanger.instance.LoadCarryWaterScene();
            } else
            {
                bouncebackTimer = 0.0f;
                bouncingBack = true;
                playerController.DisableController();
                DialogueManager.AddDialogue(bouncebackDialog[0].text, bouncebackDialog[0].portrait, bouncebackDialog[0].duration);
            }
        }
    }
}
