using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryingWaterGameOver : MonoBehaviour
{
	[SerializeField] CountdownTimer_Nathan timer;

	private void Update()
	{
		if (timer.GetTimer() <= 0)
		{
			GameOver();
		}
	}

	private void GameOver()
	{
		SceneChanger.instance.LoadCarryWaterScene();
	}
}
