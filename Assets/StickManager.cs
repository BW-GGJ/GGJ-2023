using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickManager : MonoBehaviour
{
    public static int SticksCollected { get; private set; }
    public static void StickCollected() 
    {
        SticksCollected++;
        if (SticksCollected == 5 && AudioManager.instance) AudioManager.instance.PlayWarn();
    }
    private void Update()
    {
        Debug.Log(SticksCollected);
    }
}
