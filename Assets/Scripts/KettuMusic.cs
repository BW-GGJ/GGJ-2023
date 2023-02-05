using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KettuMusic : MonoBehaviour
{
    bool hasStarted;
    private void Update()
    {
        if (!hasStarted && KetuEncounterController.isFinished && AudioManager.instance) 
        {
            AudioManager.instance.PlayTrack3();
            hasStarted = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && AudioManager.instance)
        {
            AudioManager.instance.PlayTrack1();
        }
    }
}
