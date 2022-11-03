using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AltEnemyCollision : MonoBehaviour
{
    public GameObject scr;
    AltEnemySpawn scores;
    public float gameScore;
    public GameObject gameOver;
    //public AudioSource source;
    //public AudioClip deathAudio;
    public GameObject hideControls;
    PhotonView view;


    private void Start()
    {
        scores = scr.GetComponent<AltEnemySpawn>();
    }

    private void Update()
    {
        gameScore = scores.totalScore + scores.score;
    }

    private void OnTriggerEnter(Collider collision)
    {

        //if (view.IsMine)
       // {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EndGame();
            }
       // }


    }

    public void EndGame()
    {
        Debug.Log("Game Over ");
        Debug.Log("Final Score :" + gameScore);
       /* gameOver.SetActive(true);
        hideControls.SetActive(false);
        //Time.timeScale = 0;
        Cursor.visible = true;


        //Destroy(gameObject);*/
    }
}
