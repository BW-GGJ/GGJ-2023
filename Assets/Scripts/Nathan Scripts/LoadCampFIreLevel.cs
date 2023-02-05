using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCampFIreLevel : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(wait());
    }

	IEnumerator wait()
	{
		yield return new WaitForSeconds(15);

		SceneChanger.instance.LoadCampfireScene();
	}
}
