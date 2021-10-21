using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float hp;
    public float maxhp = 100f;

    public float speed = 10f;
    private Transform destination;
    private int waypointIndex = 0;
    public HealthBar healthBar;
    public int damage = 10;
    public FinishPoint finishPoint;
    public GameObject finishPointt;


    void Start()
    {
        destination = Waypoints.points[0];
        hp = maxhp;
        healthBar.SetMaxHealth(maxhp);
    }

    void Update()
    {

        Vector3 dir = destination.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //if (Vector3.Distance(transform.position, new Vector3(70.3f, 5.13f, -1f)) <= 1f)
        //{
        //    var f = finishPointt.GetComponent<FinishPoint>();
        //    f.GetDamage(damage);
        //    Destroy(gameObject);
        //}

        if (Vector3.Distance(transform.position, destination.position) <= 0.2f)
        {
            GetNextWaypoint();
        }



    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;

        }

        waypointIndex++;
        destination = Waypoints.points[waypointIndex];

    }

    public void TakeHit(float damage) 
    {
        hp -= damage;
        healthBar.SetHealth(hp);
        if (hp <= 0) { Destroy(gameObject); }
    }
}
