using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCinematicManager : MonoBehaviour
{
    float loadNextLevelTimer = 13.0f;
    bool loadedNextLevel = false;

    [SerializeField] List<Sprite> panelSprites = new List<Sprite>();
    [SerializeField] SpriteRenderer backdropSprite;

    float firstPanelTime = 0.0f;
    float secondPanelTime = 3.0f;
    bool secondPanelTriggered = false;
    float thirdPanelTime = 8.0f;
    bool thirdPanelTriggered = false;
    float fourthPanelTime = 5.0f;
    bool fourthPanelTriggered = false;

    float panelTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.AddDialogue("These are those roots...", null);
        backdropSprite.sprite = panelSprites[0];
        panelTimer = 0.0f;

        
        
    }

    // Update is called once per frame
    void Update()
    {

        panelTimer += Time.deltaTime;
        if (panelTimer > thirdPanelTime && !fourthPanelTriggered)
        {
            fourthPanelTriggered = true;
            DialogueManager.AddDialogue("But- my brother!", null);
            backdropSprite.sprite = panelSprites[3];
        } else if (panelTimer > thirdPanelTime && !thirdPanelTriggered)
        {
            thirdPanelTriggered = true;
            DialogueManager.AddDialogue("You know what happens when you break the law!", null);
            backdropSprite.sprite = panelSprites[2];
        } else if(panelTimer > secondPanelTime && !secondPanelTriggered)
        {
            secondPanelTriggered = true;
            DialogueManager.AddDialogue("Hey!", null);
            backdropSprite.sprite = panelSprites[1];
        }

        loadNextLevelTimer -= Time.deltaTime;
        if(loadNextLevelTimer < 0 && !loadedNextLevel)
        {
            loadedNextLevel = true;
            SceneChanger.instance.LoadStartTownScene();
        }

    }
}
