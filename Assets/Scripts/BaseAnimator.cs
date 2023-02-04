using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimator : MonoBehaviour
{
    Animator thisAnimator;

    Vector2 deltaPos;
    Vector2 oldPos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        deltaPos = (Vector2)(transform.position) - oldPos;

        if (deltaPos.magnitude > .005f)
        {
            thisAnimator.SetFloat("XSpeed", deltaPos.x);
            thisAnimator.SetFloat("YSpeed", deltaPos.y);
            SetRunning(true);
        }
        else SetRunning(false);

        oldPos = transform.position;
    }

    public void SetRunning(bool newValue)
    {
        thisAnimator.SetBool("running", newValue);
    }

    public void TriggerShovel()
    {
        thisAnimator.SetTrigger("shovel");
    }

    public void TriggerCarryWater()
    {
        thisAnimator.SetTrigger("CarryWater");
    }
    /// <summary>
    /// Meant for value ranges of 0 to 1, where >.99f triggers the end of the carrying animations
    /// </summary>
    /// <param name="instabilityLevel"></param>
    public void SetCarryWaterInstability(float instabilityLevel)
    {
        thisAnimator.SetFloat("instability", instabilityLevel);
    }
}
