using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickManager : MonoBehaviour
{
    public static int SticksCollected { get; private set; }
    public static void StickCollected() 
    {
        SticksCollected++;

        //If the player has collected all of the logs
        if (SticksCollected == 5 && AudioManager.instance) AudioManager.instance.PlayWarn();
    }
}
