using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;
    public Rigidbody rb;
    float desiredMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void GetMovementInput()
    {
        desiredMovement = 0;

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            desiredMovement = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            desiredMovement = 1;

        }
        
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            desiredMovement = 0;
        }

    }

    void ApplyMovement()
    {
        if (rb != null)
        {
            rb.velocity = new Vector3(desiredMovement, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        ApplyMovement();

    }
}
