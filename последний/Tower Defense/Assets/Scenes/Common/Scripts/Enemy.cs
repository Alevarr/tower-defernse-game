using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public float hp;
    public float maxhp = 100f;
    private money money;
    public int pay=10;
    public AudioSource ded;
    public float speed = 10f;
    private Transform destination;
    private int waypointIndex = 0;
    public HealthBar healthBar;
    public float damage = 10f;
    public int power;
    //public FinishPoint finishPoint;
    //public GameObject finishPointt;
    public GameObject finishPoint;
    private Transform[] wp;


    void Start()
    {
        money = GameObject.FindWithTag("money").GetComponent<money>() ;
        finishPoint = GameObject.Find("Finish(Clone)");
        
        hp = maxhp;
        healthBar.SetMaxHealth(maxhp);
        int r = Random.Range(1, 3);
        if (r == 1)
        {
            Debug.Log("1 route");
            wp = Waypoints.points;
        } else
        {
            Debug.Log("2 route");
            wp = Waypoints2.points;
            
        }

        Debug.Log(wp.Length);

        destination = wp[0];
    }

    void Update()
    {

        Vector3 dir = destination.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        Debug.Log(Vector3.Distance(transform.position, finishPoint.transform.position));
        if (Vector3.Distance(transform.position, finishPoint.transform.position) <= 1.5f)
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
        destination = wp[waypointIndex];

    }

    public void TakeHit(float damage) 
    {
        hp -= damage;
        healthBar.SetHealth(hp);
        if (hp <= 0) 
        {
            Destroy(gameObject);
            money.earnMoney(pay);
            

        }
    }
}
