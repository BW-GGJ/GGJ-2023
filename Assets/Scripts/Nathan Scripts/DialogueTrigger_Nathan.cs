using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_Nathan : MonoBehaviour
{
	[SerializeField] StartTownStoryController storyLink;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			storyLink.TriggerCinematicEvent();
		}
	}
}
