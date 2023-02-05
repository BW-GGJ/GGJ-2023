using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetuController : MonoBehaviour
{
    [SerializeField] Animator ketuAnimator;
    [SerializeField] Animator ketuFlameAnimator;

    bool spawning = false;
    bool despawning = false;

    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        ketuAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        ketuFlameAnimator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) BeginKetuSpawnSequence();
        //if (Input.GetKeyDown(KeyCode.Backspace)) BeginKetuDespawnSequence();

        if (spawning)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                ketuAnimator.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                spawning = false;
                    Debug.Log("Done Spawning");
            }
        }
        if (despawning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ketuFlameAnimator.gameObject.SetActive(false);
                despawning = false;
            }
        }
    }

    public void BeginKetuSpawnSequence()
    {
        ketuFlameAnimator.gameObject.SetActive(true);
        ketuFlameAnimator.SetBool("Growing", true);
        spawning = true;
        timer = 1.75f;
    }

    public void BeginKetuDespawnSequence()
    {
        ketuAnimator.GetComponent<SpriteRenderer>().enabled = false;
        ketuFlameAnimator.SetBool("Growing", false);
        despawning = true;
        timer = 1.75f;
    }
}
