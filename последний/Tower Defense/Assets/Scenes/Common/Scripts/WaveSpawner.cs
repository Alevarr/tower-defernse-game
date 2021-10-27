using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public float secondsBetweenWaves = 10f;
    private float countdown = 2f;


    private int waveNumber = 0;
    
    

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = secondsBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave ()
    {
        for (int i = 0; i < waveNumber * 2 + 1; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
