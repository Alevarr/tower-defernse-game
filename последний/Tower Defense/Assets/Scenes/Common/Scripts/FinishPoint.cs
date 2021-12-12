using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinishPoint : MonoBehaviour
{

    public HealthBar HB;
    private static HealthBar healthBar;
    //private float hp;
    public float mh;
    public Camera camera;
    public AudioSource nahui;
    public static float maxhp;
    private static float hp;
    private bool lost = true;
    public GameObject proigral;
    // Start is called before the first frame update
    void Start()
    {
        nahui.Play();
        proigral = GameObject.Find("Canvas1");
        proigral.SetActive(false);
        healthBar = HB;
        maxhp = mh;
        hp = maxhp;
        healthBar.SetMaxHealth(maxhp);
    }

    void Update()
    {

        if (hp <= 0 && lost==true)
        {
            lost = false;
            camera =GameObject.Find("allUI").GetComponent<ui>().camera;
            camera.orthographicSize = 20f;
            GameObject.Find("Canvas").SetActive(false);
            GameObject.Find("allUI").GetComponent<ui>().loseText[0].text="Wave: "+ (GameObject.Find("SpawnPoint").GetComponent<WaveSpawner>().waveNumber-1).ToString();
            GameObject.Find("allUI").GetComponent<ui>().loseText[1].text = "Enemy wave power: " + GameObject.Find("allUI").GetComponent<ui>().text[0].text;
            GameObject.Find("allUI").GetComponent<ui>().loseText[2].text = "Towers power: " + GameObject.Find("allUI").GetComponent<ui>().text[1].text;
            Destroy(GameObject.Find("Squares"));
            proigral.SetActive(true);
            if (GameObject.Find("SpawnPoint").GetComponent<WaveSpawner>().EnemyPower > PlayerPrefs.GetInt("ScoreEnemy")){ PlayerPrefs.SetInt("ScoreEnemy", GameObject.Find("SpawnPoint").GetComponent<WaveSpawner>().EnemyPower); }
            if (GameObject.Find("allUI").GetComponent<ui>().TowerPower> PlayerPrefs.GetInt("ScoreTower")) { PlayerPrefs.SetInt("ScoreTower", GameObject.Find("allUI").GetComponent<ui>().TowerPower); }
            if (GameObject.Find("SpawnPoint").GetComponent<WaveSpawner>().waveNumber > PlayerPrefs.GetInt("ScoreWave")) { PlayerPrefs.SetInt("ScoreWave", GameObject.Find("SpawnPoint").GetComponent<WaveSpawner>().waveNumber-1); }

        }
    }

    public static void GetDamage(float damage)
    {
        Debug.Log("Bolno");
        hp -= damage;
        healthBar.SetHealth(hp);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

}
