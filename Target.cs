using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Target : MonoBehaviour
{
    public float health = 50f;
   
    public GameObject gm;
    AltEnemySpawn altenemy;
    AltEnemySpawn killcount;

    public AudioClip clip;
    



    private void Start()
    {
        altenemy = gm.GetComponent<AltEnemySpawn>();
        killcount = altenemy.GetComponent<AltEnemySpawn>();

    }
    
   

    

    

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        
        //altenemy.counter--;       //For infinte spawn
        AudioSource.PlayClipAtPoint(clip, transform.position, 1);
        Destroy(gameObject);
        killcount.score += 5;


        Debug.Log("Score : "+ killcount.score);
    }

    
}


