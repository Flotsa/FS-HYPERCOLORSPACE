using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject projectile;
    
    public float speed;
    public Transform instantiationLocation;



    bool wantToShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GetFireInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            wantToShoot = true;
        }
    }

    void FireProjectile()
    {
        Instantiate(projectile, instantiationLocation);
    }



    // Update is called once per frame
    void Update()
    {
        GetFireInput();
        if(wantToShoot)
        {
            
            FireProjectile();

            wantToShoot = false;
        }


    }
}
