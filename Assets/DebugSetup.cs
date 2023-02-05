using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSetup : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(startfollow());
        if (AudioManager.instance) AudioManager.instance.PlayAmbiance();
    }
    IEnumerator startfollow() 
    {
        yield return new WaitForEndOfFrame();
        CameraStateMachine.instance.SetPlayerFollow();
    }
}
