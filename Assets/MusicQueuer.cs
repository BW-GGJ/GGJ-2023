using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicQueuer : MonoBehaviour
{
    [SerializeField] private string songtoplay;
    private void Start()
    {
        if (!AudioManager.instance) return;
        switch (songtoplay.ToLower()) 
        {
            case "track1":
                AudioManager.instance.PlayTrack1();
                break;
            case "track2":
                AudioManager.instance.PlayTrack2();
                break;
            case "track3":
                AudioManager.instance.PlayTrack3();
                break;
            case "boss":
                AudioManager.instance.PlayBoss();
                break;
        }
    }
}
