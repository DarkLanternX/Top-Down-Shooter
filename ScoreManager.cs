using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    Text ScoreText;
    public GameObject scoreObj;
    AltEnemyCollision score1;

    void Start()
    {
        ScoreText = GetComponent<Text>();
        score1 = scoreObj.GetComponent<AltEnemyCollision>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score1.gameScore.ToString();
    }
}
