using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject projectile;
    
    
    public Transform instantiationLocation;

    public float shootChance = .0001f;

    bool wantToShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GetFireInput()
    {
        if(Random.value < shootChance) { wantToShoot=true; }
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
