using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerActivate : MonoBehaviour
{
	bool clock;
	[SerializeField] GameObject timerLink;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player") && !clock)
		{
			clock = true;
			timerLink.SetActive(true);
		}
	}

	
}
