using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTextTriggerNPC_Rick : MonoBehaviour
{
    [SerializeField] string chatText = "";
    [SerializeField] Sprite portraitSprite = null;
    [SerializeField] float holdTextSeconds = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DialogueManager.AddDialogue(chatText, portraitSprite, holdTextSeconds);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //DialogueManager.instance.SetActive(false);
        }
    }
}
