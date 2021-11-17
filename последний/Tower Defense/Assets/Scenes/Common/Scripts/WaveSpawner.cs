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
    public int sumPower=5;
    public int upNah = 1;

    //private Random rnd = new Random();

    public float secondsBetweenEnemies = 0.1f;
    public Text WaveNumberUI;
    public Button NextWaveButton;
    private static float countdown;
    static private bool puskaiteKrakena=false;
    public ui powertower;
    private int fixPower;
    public float koeffPower=1;
    public float kolvo=1;
    public float koeffMaxHP=1;
    public float koeff=0.001f;
    public float koeffPay=1;
    private float koeffPower1=1;
    private float koeffMaxHP1=1;
    private float koeffPay1=1;


    private int waveNumber = 1;

    
    void Start()
    {
        //enemyArray[0] = enemyNormalPrefab;
        //enemyArray[1] = enemyNormalPrefab;
        //enemyArray[2] = enemyNormalPrefab;
        powertower = GameObject.Find("allUI").GetComponent<ui>();
        countdown = TimeBetweenWaves();
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0  || puskaiteKrakena == true)
        {
            if ((countdown <= 0f))
            {
                puskaiteKrakena = false;
                WaveNumberUI.text = "Wave: " + waveNumber.ToString();
                StartCoroutine(SpawnWave());
                waveNumber++;
                countdown = TimeBetweenWaves();
            }
            powertower.text[2].GetComponent<textnextwave>().textCooldown = countdown;
            countdown -= Time.deltaTime;
        }
        koeffMaxHP1=koeffMaxHP*sumPower*koeff;
        koeffPay1=koeffPay* sumPower * koeff;
        koeffPower1=koeffPower* sumPower * koeff;
    }


    IEnumerator SpawnWave ()
    {
        int nowPower = 0;
        while (nowPower<fixPower*(1+kolvo * koeff)) 
        {
    }

    float TimeBetweenWaves()
    {
        if (waveNumber <= 5)
        {
            return 5f;
        } else
        {
            return 7f;
        }
        
    }

    int SpawnEnemy(bool close = false)
    {
        int n = Random.Range(0, 3);
        int powerEnemy = 0;
        GameObject vrag = null;
        //if (powerEnemy < towerPower)
        //{
        //    SpawnEnemy(true);
        //}
        switch (n)
        {
            case 0:
                vrag = (GameObject)Instantiate(enemyNormalPrefab, transform.position, transform.rotation);
                improveVrag(vrag);
                powerEnemy = vrag.GetComponent<enemy>().power;
                break;
            case 1:
                vrag = (GameObject)Instantiate(enemyHeavyPrefab, transform.position, transform.rotation);
                improveVrag(vrag);
                powerEnemy = vrag.GetComponent<enemy>().power;
                break;
            case 2:
                vrag = (GameObject)Instantiate(enemyQuickPrefab, transform.position, transform.rotation);
                improveVrag(vrag);
                powerEnemy = vrag.GetComponent<enemy>().power;
                break;
            default:
                break;
        }
        return powerEnemy;
    }
    void improveVrag(GameObject vrag) 
    {
        vrag.GetComponent<enemy>().power = (int)Mathf.Round(vrag.GetComponent<enemy>().power*(1+koeffPower1));
        vrag.GetComponent<enemy>().maxhp *= (1+koeffMaxHP1);
        vrag.GetComponent<enemy>().pay *= (int)Mathf.Round(1+koeffPay1);
    }

    public static void SkipToNextWave()
    {
        puskaiteKrakena = true;
    }
}
