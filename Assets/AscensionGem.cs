using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensionGem : MonoBehaviour
{
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 4)
        {
            timer += Time.deltaTime;

            if(timer >= 4)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<CircleCollider2D>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Pickup bonuses here

    }
}
