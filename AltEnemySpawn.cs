using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;

public class AltEnemySpawn : MonoBehaviour
{
   [SerializeField] public GameObject[] enemy;  //Enemies variants have different hp and speed
    public float counter = 0f;  //Checks number of enemies
    public float maxEnemy;         //Max number of enemy in a single wave 
    public int wave = 1;
    NavMeshAgent agent;
    public GameObject walls;
    public GameObject WaveScreen;
    public GameObject buff;
    public float totalScore = 0;

    public Vector3[] spawnPt;

    //public int xPos;            //Enemy Spawn Coords
    //public int zPos;


    public float score = 0f;    //Tracks killcount



   

    private void Start()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            agent = enemy[i].GetComponent<NavMeshAgent>();
        }

        StartCoroutine(Spawn());

    }

    IEnumerator Spawn()
    {
        while (true)
        {
            if (counter < maxEnemy)
            {
                /*xPos = Random.Range(230, 260);
                zPos = Random.Range(50, 250);*/
                //Instantiate(enemy[Random.Range(0,enemy.Length)], new Vector3(xPos, 7.303f, zPos), Quaternion.identity);       //Spawn Enemies at random coords given above
                Instantiate(enemy[Random.Range(0, enemy.Length)],  spawnPt[Random.Range(0, spawnPt.Length)], Quaternion.identity);      //Fixed multiple Spawn Points
                counter++;
                Debug.Log("Enemy count :" + counter);
            }
            if ((score/5) == maxEnemy)          
            {
                Debug.Log("You Survived");
                wave++;
                totalScore = score + totalScore;
                Debug.Log("WAVE " + wave);
                counter = 0;
                score = 0f;
                maxEnemy += 50;     //increment max enemy with 50 after every wave


                agent.speed += 5;          //Increment enemy speed by 5 after every wave
                walls.SetActive(true);      //can change level without needing multiple scenes
                WaveScreen.SetActive(true); 
                
                buff.SetActive(true);           
                yield return new WaitForSeconds(5f);
                WaveScreen.SetActive(false);

            }
            yield return new WaitForSeconds(0.1f);


        }

    }





}




