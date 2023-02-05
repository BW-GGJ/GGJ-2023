using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingHall_Nathan : MonoBehaviour
{
	int pass = 1;
	[SerializeField] GameObject triggerLink;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			if (pass < 5)
			{
				collision.gameObject.transform.position = new Vector3(47, 16, 0);
				pass++;
				if (pass == 3) triggerLink.SetActive(true);
			}
			else
			{
				collision.gameObject.transform.position = new Vector3(-14, -9, 0);
			}
		}
	}
}
