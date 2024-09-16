using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    
    public float speed;
    float timeToDestroy = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Expire", timeToDestroy);
        
        transform.parent = null;
    }

    void Expire()
    {
        Destroy(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
     
        transform.Translate(0, -speed*Time.deltaTime, 0);
    }
}
