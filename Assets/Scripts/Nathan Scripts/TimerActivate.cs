using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerActivate : MonoBehaviour
{
	bool clock;
	[SerializeField] GameObject timerLink;

    // Update is called once per frame
    void Update()
    {
        if (KetuEncounterController.isFinished && !clock)
		{
			clock = true;
			timerLink.SetActive(true);
		}
    }
}
