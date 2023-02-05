using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAnimation : MonoBehaviour
{
    public static StickAnimation instance;
    [SerializeField] private GameObject fire;
    [SerializeField] private Color[] colors;
    public bool woodState { get; private set; }
    private void Awake()
    {
        if(!instance) instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Fire") 
        {
            noWood();
        }
    }

    public void HasWood() 
    {
        GetComponent<Animator>().SetFloat("hasWood", 0.1f);
        woodState = true;
    }
    public void noWood()
    {
        GetComponent<Animator>().SetFloat("hasWood", 0.0f);
        woodState = false;
        CampfireHUD.instance.Refresh();
        fire.GetComponent<SpriteRenderer>().color = colors[StickManager.SticksCollected - 1];
    }

    private void Update()
    {
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        move.Normalize();

        GetComponent<Animator>().SetFloat("Velocity", move.magnitude);
        if (move.magnitude > 0f) {
            GetComponent<Animator>().SetFloat("XSpeed", move.x);
            GetComponent<Animator>().SetFloat("YSpeed", move.y);
        }
    }
}
