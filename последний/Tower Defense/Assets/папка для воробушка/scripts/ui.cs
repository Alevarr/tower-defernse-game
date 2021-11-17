using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{
    public Text[] text;
    private int TowerPower = 0;
    public int offsetPower = 10;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("SpawnPoint").GetComponent<WaveSpawner>().sumPower = offsetPower;
    }


    public void UpdateTowerPower(int x)
    {
        TowerPower += x;
        text[1].text = TowerPower.ToString();
        GameObject.Find("SpawnPoint").GetComponent<WaveSpawner>().sumPower = TowerPower;
        
    }

    public void UpdateEnemyPower(int x)
    {
        text[0].text = (x).ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
