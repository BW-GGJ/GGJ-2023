/**
 * StartIceBucket.cs
 * By Nathan Boles
 * 
 * This script simply checks if the player is in the location they need to be. If they are, it starts the Water Carrying Challenge and activates all the components needed for it.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIceBucket : MonoBehaviour
{
	[SerializeField] GameObject challengeHud;
	[SerializeField] GameObject brotherTriggerLink;
	[SerializeField] BaseAnimator animatorLink;
	[SerializeField] GameObject followTrigger;
	[SerializeField] GameObject ignoreTrigger;
	[SerializeField] GameObject oldTrigger;

	bool wasIgnored = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	/// <summary>
	/// An OnTriggerStay that checks if the player is within the trigger. If they are, they can use the Submit button to start the challenge
	/// </summary>
	/// <param name="collision">the object that is colliding with this trigger.</param>
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			//Debug.Log("Start");
			//Debug.Log("Bucket Animation");
			animatorLink.TriggerCarryWater();
			animatorLink.SetCarryWaterInstability(0);
			challengeHud.SetActive(true);
			brotherTriggerLink.SetActive(true);
			gameObject.SetActive(false);
			oldTrigger.SetActive(false);
			if (wasIgnored) followTrigger.SetActive(true);
			else ignoreTrigger.SetActive(true);
		}
	}

	public void setIgnore(bool newIgnore)
	{
		wasIgnored = newIgnore;
	}
}
