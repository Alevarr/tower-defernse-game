using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{

    public HealthBar mainHealthBar;
    public Transform finishPoint;
    public int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        mainHealthBar.SetMaxHealth(hp);
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        mainHealthBar.SetHealth(hp);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
