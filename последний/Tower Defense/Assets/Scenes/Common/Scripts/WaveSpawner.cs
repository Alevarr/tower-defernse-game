using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyNormalPrefab;
    public Transform enemyHeavyPrefab;
    public Transform enemyQuickPrefab;
    private Transform[] enemyArray;//{enemyNormalPrefab, enemyHeavyPrefab, enemyQuickPrefab};

    //private Random rnd = new Random();

    public float secondsBetweenEnemies = 0.5f;
    public Text WaveNumberUI;
    public Button NextWaveButton;
    private static float countdown;


    private int waveNumber = 1;

    
    void Start()
    {
        //enemyArray[0] = enemyNormalPrefab;
        //enemyArray[1] = enemyNormalPrefab;
        //enemyArray[2] = enemyNormalPrefab;
        countdown = TimeBetweenWaves();
    }
    void Update()
    {
        if (countdown <= 0f)
        {
            WaveNumberUI.text = "Wave: " + waveNumber.ToString();
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenWaves();
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave ()
    {
        for (int i = 1; i < waveNumber * 1.5f; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(secondsBetweenEnemies);
        }
        waveNumber++;
    }

    float TimeBetweenWaves()
    {
        if (waveNumber <= 5)
        {
            return 5f;
        } else
        {
            return waveNumber;
        }
        
    }

    void SpawnEnemy()
    {
        int n = Random.Range(0, 3);
        switch (n)
        {
            case 0:
                Instantiate(enemyNormalPrefab, transform.position, transform.rotation);
                break;
            case 1:
                Instantiate(enemyHeavyPrefab, transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(enemyQuickPrefab, transform.position, transform.rotation);
                break;
            default:
                break;
        }
        Debug.Log(n);
    }

    public static void SkipToNextWave()
    {
        countdown = 0;
    }
}
