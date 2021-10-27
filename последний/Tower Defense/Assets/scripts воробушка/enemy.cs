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
    public float damage = 10f;
    //public FinishPoint finishPoint;
    //public GameObject finishPointt;
    public GameObject finishPoint;


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

        if (Vector3.Distance(transform.position, finishPoint.transform.position) <= 1f)
        {
           
            DealDamage();
            Destroy(gameObject);
        }

        if (Vector3.Distance(transform.position, destination.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void DealDamage()
    {
        Debug.Log("Damage to deal: " + damage);
        //FinishPoint f = FinishPoint.GetComponent<FinishPoint>();
        FinishPoint.GetDamage(damage);
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
