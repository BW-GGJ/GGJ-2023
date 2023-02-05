using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KettuBossAI : MonoBehaviour
{
    [SerializeField] GameObject followTarget;
    [SerializeField] float moveSpeed = 4.0f;

    [SerializeField] Animator thisAnimator;

    int hitsLeft = 2;
    [SerializeField] GameObject firstEnsnareRoot;
    [SerializeField] GameObject secondEnsnareRoot;

    bool beingHit = false;
    float beingHitTimer = 0.0f;

    [SerializeField] GameObject lilyRootPrefab;
    float lilyTimer = 0.0f;
    float lilyTime = 17.0f;

    [SerializeField] List<CinematicDialogElements> brotherChats = new List<CinematicDialogElements>();

    float oldX = 0f;
    float deltaX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        firstEnsnareRoot.SetActive(false);
        secondEnsnareRoot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)) TakeHit();

        lilyTimer += Time.deltaTime;
        if(lilyTimer >= lilyTime)
        {
            lilyTimer -= lilyTime;
            float ranX = Random.Range(-19, 19);
            float ranY = Random.Range(-12, 12);

            Instantiate(lilyRootPrefab, new Vector3(followTarget.transform.position.x + ranX, followTarget.transform.position.y + ranY, 0), Quaternion.identity);

        }
    }

    private void FixedUpdate()
    {
        if (followTarget == null) return;

        if (beingHit)
        {
            beingHitTimer -= Time.fixedDeltaTime;
            if(beingHitTimer <= 0)
            {
                beingHit = false;
                if (hitsLeft == 1)
                {
                    Destroy(firstEnsnareRoot);
                }
                else if (hitsLeft == 0)
                {
                    Destroy(secondEnsnareRoot);
                }
                else Destroy(gameObject, 4f);
            }
        }
        else if(hitsLeft >= 0) transform.position = Vector3.MoveTowards(transform.position, followTarget.transform.position, moveSpeed * Time.fixedDeltaTime);

        deltaX = transform.position.x - oldX;
        thisAnimator.SetFloat("XSpeed", deltaX);
        oldX = transform.position.x;
    }
    void TakeHit()
    {
        thisAnimator.SetTrigger("LegEnsnared");
        beingHit = true;
        beingHitTimer = 1.5f;
        if(hitsLeft == 2)
        {
            hitsLeft--;
            firstEnsnareRoot.SetActive(true);
            
            DialogueManager.AddDialogue(brotherChats[0].text, brotherChats[0].portrait, brotherChats[0].duration);
        } else if (hitsLeft == 1)
        {
            hitsLeft--;
            secondEnsnareRoot.SetActive(true);
            DialogueManager.AddDialogue(brotherChats[1].text, brotherChats[1].portrait, brotherChats[1].duration);
        } else if (hitsLeft == 0)
        {
            hitsLeft--;
            DialogueManager.AddDialogue(brotherChats[2].text, brotherChats[2].portrait, brotherChats[2].duration);
        }
    }

    public void SetFollowTarget(GameObject newTarget)
    {
        followTarget = newTarget;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "LilyRoot")
        {
            TakeHit();
            Destroy(collision.gameObject);
        }
    }
}
