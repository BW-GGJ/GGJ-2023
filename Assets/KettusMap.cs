using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KettusMap : MonoBehaviour
{
    [SerializeField] List<CinematicDialogElements> mapDialog = new List<CinematicDialogElements>();
    [SerializeField] LoadCarryWaterLevel zoneExit;

    bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !triggered)
        {
            zoneExit.CollectedMap();
            foreach(CinematicDialogElements x in mapDialog)
            {
                DialogueManager.AddDialogue(x.text, x.portrait, x.duration);
            }
            AudioManager.instance.PlayPickup();
            Destroy(gameObject);
            triggered = true;
        }
    }
}
