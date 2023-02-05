using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCampFIreLevel : MonoBehaviour
{
	bool activated;

    // Start is called before the first frame update
    void Update()
    {
		if (!activated)
		{
			StartCoroutine(wait());
			activated = true;
		}
    }

	IEnumerator wait()
	{
		yield return new WaitForSeconds(15);

		SceneChanger.instance.LoadCampfireScene();
	}
}
