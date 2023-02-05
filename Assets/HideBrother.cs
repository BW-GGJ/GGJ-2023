using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBrother : MonoBehaviour
{
    [SerializeField] private GameObject brother;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (StickManager.SticksCollected == 5) 
        {
            brother.SetActive(false);
            CampfireHUD.instance.OverrideText("Find Brother.");

            Destroy(gameObject);
        }
    }
}
