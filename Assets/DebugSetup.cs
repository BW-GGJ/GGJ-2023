using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSetup : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(startfollow());
    }
    IEnumerator startfollow() 
    {
        yield return new WaitForSeconds(1f);
        CameraStateMachine.instance.SetPlayerFollow();
    }
}
