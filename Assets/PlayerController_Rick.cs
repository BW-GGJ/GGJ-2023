using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Rick : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveVector += Vector3.up;
        if (Input.GetKey(KeyCode.A)) moveVector += Vector3.left;
        if (Input.GetKey(KeyCode.S)) moveVector += Vector3.down;
        if (Input.GetKey(KeyCode.D)) moveVector += Vector3.right;

        moveVector.Normalize();

        transform.Translate(moveVector * Time.deltaTime * playerSpeed);
    }
}
