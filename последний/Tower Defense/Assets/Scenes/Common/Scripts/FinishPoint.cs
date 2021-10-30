using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{

    public HealthBar HB;
    private static HealthBar healthBar;
    //private float hp;
    public float mh;
    public AudioSource nahui;
    public static float maxhp;
    private static float hp;
    // Start is called before the first frame update
    void Start()
    {
        nahui.Play();
        healthBar = HB;
        maxhp = mh;
        hp = maxhp;
        healthBar.SetMaxHealth(maxhp);
    }

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }

    public static void GetDamage(float damage)
    {
        hp -= damage;
        healthBar.SetHealth(hp);

    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

}
