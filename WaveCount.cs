using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCount : MonoBehaviour
{
    Text WaveText;
    public GameObject waveObj;
    AltEnemySpawn waveCount;

    void Start()
    {
        WaveText = GetComponent<Text>();
        waveCount = waveObj.GetComponent<AltEnemySpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        WaveText.text = waveCount.wave.ToString();
    }
}
