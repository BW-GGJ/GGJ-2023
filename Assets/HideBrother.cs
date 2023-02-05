using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBrother : MonoBehaviour
{
    [SerializeField] private GameObject brother;
    [SerializeField] private GameObject Footsteps;
    [SerializeField] private GameObject RoadBlocks;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (StickManager.SticksCollected == 5) 
        {
            brother.SetActive(false);
            RoadBlocks.SetActive(false);

            Footsteps.SetActive(true);
            CampfireHUD.instance.OverrideText("Find Brother.");

            Destroy(gameObject);
        }
    }
}
