using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KettuShadowController : MonoBehaviour
{
    [SerializeField] GameObject runAwayLocation;
    [SerializeField] Animator kettuAnimator;

    bool runninAway = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (runninAway)
        {
            transform.position = Vector3.MoveTowards(transform.position, runAwayLocation.transform.position, 8 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            kettuAnimator.SetTrigger("StartRunning");
            runninAway = true;
        }
    }
}
