using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CampfireHUD : MonoBehaviour
{
    public static CampfireHUD instance;
    public bool overridenen;
    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void Refresh() 
    {
        if (overridenen) return;
        GetComponent<TMP_Text>().text = $"Place logs in the fire. ({StickManager.SticksCollected}/5)";
    }
    public void OverrideText(string text) 
    {
        overridenen = true;
        GetComponent<TMP_Text>().text = text;
    }
}
