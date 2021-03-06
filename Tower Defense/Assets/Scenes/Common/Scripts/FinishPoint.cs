using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{

    public HealthBar HB;
    private static HealthBar healthBar;
    //private float hp;
    public float mh;
    public static float maxhp;
    private static float hp;
    // Start is called before the first frame update
    void Start()
    {
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
