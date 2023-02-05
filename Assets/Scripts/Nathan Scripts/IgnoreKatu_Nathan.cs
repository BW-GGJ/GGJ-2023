using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreKatu_Nathan : MonoBehaviour
{
	[SerializeField] StartIceBucket trigger;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			trigger.setIgnore(true);
		}
	}
}
