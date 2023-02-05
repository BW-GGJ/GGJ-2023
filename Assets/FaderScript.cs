using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderScript : MonoBehaviour
{
    public static FaderScript instance;
    LTDescr fade;
    private void Awake()
    {
        if(!instance) instance = this;
    }

    public void FadeIn(float duration = 1f) 
    {
        Debug.Log("Fade in");
        if (fade != null) 
        {
            LeanTween.cancel(fade.id);
        }
        fade = LeanTween.alpha(GetComponent<RectTransform>(), 1f, duration);
    }
    public void FadeOut(float duration = 1f)
    {
        Debug.Log("Fade out");
        if (fade != null)
        {
            LeanTween.cancel(fade.id);
        }
        fade = LeanTween.alpha(GetComponent<RectTransform>(), 0f, duration);
    }
}
