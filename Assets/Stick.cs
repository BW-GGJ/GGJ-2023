using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (AudioManager.instance) AudioManager.instance.PlayPickup();
        StickManager.StickCollected();
        Destroy(gameObject);
    }
}
