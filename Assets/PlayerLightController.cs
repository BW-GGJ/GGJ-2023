using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerLightController : MonoBehaviour
{
    [SerializeField] GameObject ArenaLight, CampLight;
    [SerializeField] float turnOff, campTurnOff;
    void Update()
    {
        //if ArenaIsCloser
        if (Vector2.Distance(ArenaLight.transform.position, transform.position) < Vector2.Distance(CampLight.transform.position, transform.position)) 
        {
            if (Vector2.Distance(ArenaLight.transform.position, transform.position) < campTurnOff) 
            {
                GetComponent<Light2DBase>().enabled = false;
                return;
            }
        }
        if (Vector2.Distance(ArenaLight.transform.position, transform.position) > Vector2.Distance(CampLight.transform.position, transform.position))
        {
            if (Vector2.Distance(CampLight.transform.position, transform.position) < turnOff)
            {
                GetComponent<Light2DBase>().enabled = false;
                return;
            }
        }
        GetComponent<Light2DBase>().enabled = true;
    }
}
