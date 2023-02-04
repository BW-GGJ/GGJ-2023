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
			if (Input.GetAxis("Submit") > 0 || Input.GetAxis("Fire1") > 0)
			{
				//Debug.Log("Start");
				//Debug.Log("Bucket Animation");
				animatorLink.TriggerCarryWater();
				challengeHud.SetActive(true);
				brotherTriggerLink.SetActive(true);
				gameObject.SetActive(false);
			}
		}
	}
}
