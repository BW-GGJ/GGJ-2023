using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearableSnow : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ShovelHit>() != null)
        {
            GetComponent<Animator>().SetTrigger("ClearSnow");
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
