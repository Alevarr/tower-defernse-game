using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyNormalPrefab;
    public GameObject enemyHeavyPrefab;
    public GameObject enemyQuickPrefab;
    private Transform[] enemyArray;//{enemyNormalPrefab, enemyHeavyPrefab, enemyQuickPrefab};
    public int sumPower=0;
    public int upNah = 1;

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
            waveNumber++;
            countdown = TimeBetweenWaves();
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave ()
    {
        int nowPower = 0;
        sumPower += upNah;
        while (nowPower<sumPower+upNah) 
        {
            nowPower+=SpawnEnemy();
            yield return new WaitForSeconds(secondsBetweenEnemies);
        }
        
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

    int SpawnEnemy()
    {
        int n = Random.Range(0, 3);
        int powerEnemy = 0;
        GameObject vrag = null;
        switch (n)
        {
            case 0:
                vrag=(GameObject)Instantiate(enemyNormalPrefab, transform.position, transform.rotation);
                improveVrag(vrag);
                powerEnemy = enemyNormalPrefab.GetComponent<enemy>().power;
                break;
            case 1:
                vrag = (GameObject)Instantiate(enemyHeavyPrefab, transform.position, transform.rotation);
                improveVrag(vrag);
                powerEnemy = enemyHeavyPrefab.GetComponent<enemy>().power;
                break;
            case 2:
                vrag = (GameObject)Instantiate(enemyQuickPrefab, transform.position, transform.rotation);
                improveVrag(vrag);
                powerEnemy = enemyQuickPrefab.GetComponent<enemy>().power;
                break;
            default:
                break;
        }
        return powerEnemy;
    }
    void improveVrag(GameObject vrag) 
    {
        vrag.GetComponent<enemy>().power = (int)Mathf.Round(vrag.GetComponent<enemy>().power*Mathf.Pow(1.5f, waveNumber / 5));
        vrag.GetComponent<enemy>().maxhp *= Mathf.Pow(1.5f, waveNumber / 5);
        vrag.GetComponent<enemy>().pay *= (int)Mathf.Round(Mathf.Pow(1.5f, waveNumber / 5));
    }

    public static void SkipToNextWave()
    {
        countdown = 0;
    }
}
