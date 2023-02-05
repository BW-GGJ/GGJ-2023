using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToLoop_Nathan : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			collision.gameObject.transform.position = new Vector3(47, 32, 0);
		}
	}
}
