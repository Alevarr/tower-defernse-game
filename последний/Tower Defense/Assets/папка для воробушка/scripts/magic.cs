using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class magic : MonoBehaviour
{
    public bool EnemyPower;
    public bool TowerPower;
    public bool WaveScore;
    [SerializeField]
    private TextMeshProUGUI m_Object;
    // Start is called before the first frame update
    void Start()
    {
        if (EnemyPower) { m_Object.text = "Enemy Power Score: "+PlayerPrefs.GetInt("ScoreEnemy").ToString(); }
        if (TowerPower) { m_Object.text = "Tower Power Score: " + PlayerPrefs.GetInt("ScoreTower").ToString(); }
        if (WaveScore) { m_Object.text = "Wave Score: " + PlayerPrefs.GetInt("ScoreWave").ToString(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
