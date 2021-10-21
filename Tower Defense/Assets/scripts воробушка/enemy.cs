using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float hp;
    public float maxhp=100;
    public healthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxhp;
        healthBar.HpSet(hp, maxhp);
    }
    public void TakeHit(float damage) 
    {
        hp -= damage;
        if (hp <= 0) { Destroy(gameObject); }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
