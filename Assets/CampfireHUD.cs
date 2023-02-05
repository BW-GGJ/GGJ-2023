using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CampfireHUD : MonoBehaviour
{
    public static CampfireHUD instance;
    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void Refresh() 
    {
        GetComponent<TMP_Text>().text = $"Place logs in the fire. ({StickManager.SticksCollected}/5)";
    }
}
