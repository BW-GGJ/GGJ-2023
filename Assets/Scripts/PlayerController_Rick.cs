using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Rick : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5;
    Vector3 moveVector = Vector3.zero;

    [SerializeField] bool shovelingAllowed = false;
    bool shoveling = false;
    float shovelTimer = 0.0f;
    float shovelTime = 0.6f;

    [SerializeField] GameObject shovelHitPrefab;

    bool controllerDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerDisabled) return;

        if (shovelingAllowed && Input.GetMouseButtonDown(0) && !shoveling)
        {
            GetComponent<BaseAnimator>().TriggerShovel();
            Instantiate(shovelHitPrefab, transform.position + (Vector3.down * .5f), Quaternion.identity);
            Debug.Log("Shoveling");
            shoveling = true;
            shovelTimer = 0.0f;
        }
        if (shoveling)
        {
            shovelTimer += Time.deltaTime;
            if(shovelTimer > shovelTime)
            {
                shoveling = false;
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (shoveling) return;

        moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveVector += Vector3.up;
        if (Input.GetKey(KeyCode.A)) moveVector += Vector3.left;
        if (Input.GetKey(KeyCode.S)) moveVector += Vector3.down;
        if (Input.GetKey(KeyCode.D)) moveVector += Vector3.right;

        moveVector.Normalize();
        transform.Translate(moveVector * Time.fixedDeltaTime * playerSpeed);
    }

    public void DisableController()
    {
        controllerDisabled = true;
    }
    public void EnableController()
    {
        controllerDisabled = false;
    }
}
