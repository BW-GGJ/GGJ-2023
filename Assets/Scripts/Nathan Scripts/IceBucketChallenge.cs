/**
 * IceBucketChallenge.cs
 * By Nathan Boles
 * 
 * This script is meant for the water bucket minigame where the character has to reach the brother with the water without spilling it.
 * It checks to see if the character is moving, then if they are, it will build up a meter. If the character isn't moving, slowly reduce the meter.
 * If the meter reaches a certain meter, the bucket is dropped.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBucketChallenge : MonoBehaviour
{
	[Tooltip("The current value of the slip meter")]
	[SerializeField] float slipMeter = 0f;
	[Tooltip("The maximum value of the slip meter")]
	[SerializeField] float maxSlipMeter = 10f;
	[Tooltip("This is the amount the meter increases per frame")]
	[SerializeField] float slipMeterGain = 0.01f;
	[Tooltip("This is the amount the meter decreases per frame")]
	[SerializeField] float slipMeterDown = 0.02f;
	bool gameOver = false;

	[Tooltip("The object currently holding the MeterController script that this script interacts with")]
	[SerializeField] MeterController_Nathan meter;

	[Tooltip("Link the player prefab to here")]
	[SerializeField] BaseAnimator animatorLink;
	[Tooltip("The Canvas gameobject that contains all the challenge HUD stuff")]
	[SerializeField] GameObject challengeHUD;
	[Tooltip("The trigger collider that starts this challenge")]
	[SerializeField] GameObject lakeLink;
	
	// Start is called before the first frame update
    void Start()
    {
		meter.SetMaxValue(maxSlipMeter);
    }

    // Update is called once per frame
    void Update()
    {
		if (slipMeter < maxSlipMeter)
		{
			//Using default input methodology for the time being. This script is checking if there's any input. May be better to test if the character is actually moving in hindsight.
			//Will likely changes as the script developes
			if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) 
			{
				slipMeter += slipMeterGain;
			}
			else if (slipMeter > 0)
			{
				slipMeter -= slipMeterDown;
				if (slipMeter < 0)
					slipMeter = 0;
			}
			meter.SetMeter(slipMeter);
			animatorLink.SetCarryWaterInstability(meter.GetNormalizedMeter());
		}
		else if (!gameOver)
		{
			//Debug.Log("Game Over");
			gameOver = true;
			challengeHUD.SetActive(false);
			lakeLink.SetActive(true);
		}
			
		//A proper game over scene will likely be called here
		
    }
	

	/// <summary>
	/// A simple getter as I keep forgetting how to do it the easy way and this is just how it has been ingrained in me. 
	/// Probably best used for any meter that someone builds that could use a value like this so that it can fill in real time.
	/// </summary>
	/// <returns>slipMeter</returns>
	public float GetSlipMeter()
	{
		return slipMeter;
	}

	/// <summary>
	/// A simple getter as I keep forgetting how to do it the easy way and this is just how it has been ingrained in me. 
	/// Probably best used for any meter that someone builds that could use a value like this so that it can fill in real time.
	/// </summary>
	/// <returns>maxSlipMeter</returns>
	public float GetMaxSlipMeter()
	{
		return maxSlipMeter;
	}
}
