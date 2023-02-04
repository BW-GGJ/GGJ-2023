using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherScript : MonoBehaviour
{
    [SerializeField] GameObject followTarget;
    [SerializeField] Sprite layingDownSprite;
    [SerializeField] bool layingDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position,followTarget.transform.position) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, followTarget.transform.position, 4.0f * Time.deltaTime);
        }
    }
}
