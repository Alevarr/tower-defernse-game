using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    public Transform target;
    public GameObject targetObj;
    public Transform partToRotate; 
    public float range = 15f;
    public float rotspeed = 10f; 
    public float reload=1f;
    private float fireCountDown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) 
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        if (target.position.x < transform.position.x)
        { partToRotate.rotation = Quaternion.Euler(0f, 0f, 180 + rotation.x); }
        else 
        {
            partToRotate.rotation = Quaternion.Euler(0f, 0f, 360-rotation.x);
        }
        if (fireCountDown <= 0f) 
        {
            Shoot();
            fireCountDown = reload;
        }
        fireCountDown -= Time.deltaTime;


    }
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistanse = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= shortestDistanse)
            {
                shortestDistanse = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if (nearestEnemy != null && shortestDistanse <= range)
            {
                target = nearestEnemy.transform;
                targetObj = nearestEnemy;
            }
            else 
            {
                target = null;
                targetObj = null;
            }
        }
    }
    void Shoot() 
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletGo.GetComponent<bullet>();
        if (bullet != null) 
        {
            bullet.Seek(target,targetObj);
        } 
          
    }
}
