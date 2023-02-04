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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (Input.GetAxis("Submit") > 0)
			{
				Debug.Log("Start");
				Debug.Log("Bucket Animation");
				challengeHud.SetActive(true);
			}
		}
	}
}
