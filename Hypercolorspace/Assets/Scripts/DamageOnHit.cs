using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            GameEngine.Instance.LoseLife();
        }

        if(other.CompareTag("Enemy"))
        {
            GameEngine.Instance.addScore(other.GetComponent<ScoreToAddOnDeath>().getScoreToAdd());
            GameEngine.Instance.EnemyKilled();
            Destroy(other.transform.parent.gameObject);
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
