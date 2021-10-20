using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    public Transform target;
    public Transform partToRotate; 
    public float range = 15f;
    public float rotspeed = 10f;
    private GameObject nearestEnemy;
    public float fireRate=1f;
    private float fireCountDown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) 
        {
            return;
        }
        /*Vector3 dir = target.position-transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * rotspeed).eulerAngles;         //lookRotation.eulerAngles; 
        partToRotate.rotation = Quaternion.Euler(0f,0f,rotation.z);
        partToRotate.LookAt(target);*/
        partToRotate.LookAt(target);
        var eulers = partToRotate.eulerAngles;
        eulers.y = 0;
        partToRotate.rotation = Quaternion.EulerAngles(eulers);

        if (fireCountDown <= 0f) 
        {
            Shoot();
            fireCountDown = 1 / fireRate;
        }
        fireCountDown -= Time.deltaTime;


    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistanse = Mathf.Infinity;
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
                return;
            }
        }
    }
    void Shoot() 
    {
        GameObject bulletGo=(GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet bullet = bulletGo.GetComponent<bullet>();
        if (bullet != null) 
        {
            bullet.Seek(target);
        } 
          
    }
}
