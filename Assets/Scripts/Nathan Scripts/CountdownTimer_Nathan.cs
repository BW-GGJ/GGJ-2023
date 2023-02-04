/**
 * CountdownTimer_Nathan.cs
 * By Nathan Boles
 * 
 * This is a simple countdown timer. It only counts in seconds at this time, so no milisecond stuff, but this
 * does give the attached meterLink a nice ticking motion as the seconds count away.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer_Nathan : MonoBehaviour
{
	[SerializeField] int timeSecondsSet = 60;
	[SerializeField] int timeSecondsRemaining;
	[SerializeField] MeterController_Nathan meterLink;
	bool wait;

    // Start is called before the first frame update
    void Start()
    {
		timeSecondsRemaining = timeSecondsSet;
		meterLink.SetMaxValue(timeSecondsSet);
		meterLink.FillMeterToMax();
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait && timeSecondsRemaining > 0)
		{
			StartCoroutine(Tick());
			wait = true;
		}
    }

	IEnumerator Tick()
	{
		yield return new WaitForSeconds(1);
		timeSecondsRemaining--;
		meterLink.SetMeter(timeSecondsRemaining);
		wait = false;
	}

	public int GetTimer()
	{
		return timeSecondsRemaining;
	}
}
