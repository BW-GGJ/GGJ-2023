/**
 * IceBucketTurnin.cs
 * By Nathan Boles
 * 
 * This script simply checks if the player is in the location they need to be. If they are, it completes the Water Carrying Challenge and disables all the components needed for it.
 * (I may look at combining this with other TriggerStay2D scripts through the use of a parent script)
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBucketTurnin : MonoBehaviour
{
	[SerializeField] GameObject challengeHud;
	[SerializeField] BaseAnimator animatorLink;
	bool triggered = false;
	[SerializeField] GameObject ending;
	[SerializeField] GameObject timer;

	/// <summary>
	/// An OnTriggerStay that checks if the player is within the trigger. If they are, they can use the Submit button to complete the challenge
	/// </summary>
	/// <param name="collision">the object that is colliding with this trigger.</param>
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player") && !triggered)
		{
			//Debug.Log("WIN");
			//Debug.Log("Normal Animation");
			animatorLink.SetCarryWaterInstability(1);
			challengeHud.SetActive(false);
			gameObject.SetActive(false);
			triggered = true;
			ending.SetActive(true);
			timer.SetActive(false);
		}
	}
}
