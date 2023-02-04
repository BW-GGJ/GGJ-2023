using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBucketTurnin : MonoBehaviour
{
	[SerializeField] GameObject challengeHud;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (Input.GetAxis("Submit") > 0)
			{
				Debug.Log("WIN");
				Debug.Log("Normal Animation");
				challengeHud.SetActive(false);
			}
		}
	}
}
