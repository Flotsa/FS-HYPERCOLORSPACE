using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swarm : MonoBehaviour
{
    public float speed = 1;
    int direction = 1;
    public float approachDistancePerBounce;
    public Rigidbody rb;

    public void changeDir()
    {
        direction = direction*-1;
    }

    public void approachPlayer()
    {
        transform.Translate(0, -approachDistancePerBounce, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb != null)
        {
            rb.velocity = new Vector3(direction*speed, 0, 0);
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb != null)
        {
            changeDir();
            approachPlayer();
            speed += .001f;
        }
    }

    
}
