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
    void Update()
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
}
