using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tower : MonoBehaviour
{
    [SerializeField]
    public GameObject rangeCircle;
    private GameObject upTower;
    public ui powertower;
    public LayerMask road;
    public UpdateTower updateTowers;
    public int number=0;
    public Transform target;
    public GameObject targetObj;
    public Transform partToRotate;
    public float range = 15f;
    public float rotspeed = 10f;
    public float reload = 1f;
    private float fireCountDown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public int cost;
    public int damage;
    public int upgradeCost = 0;
    public string comentUpgrade;



    // Start is called before the first frame update
    void Start()
    {
        powertower = GameObject.Find("allUI").GetComponent<ui>();
        rangeCircle.transform.localScale = new Vector3(1f, 1f, 0f) * range;
        upTower = GameObject.Find("TowerUpgrade");
        updateTowers = upTower.GetComponent<UpdateTower>();
        GetComponent<CircleCollider2D>().radius = range/2;
        powertower.UpdateTowerPower(PowerThisTower());
        GetComponent<CircleCollider2D>().enabled = false;
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
            partToRotate.rotation = Quaternion.Euler(0f, 0f, 360 - rotation.x);
        }
        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = reload;
        }
        fireCountDown -= Time.deltaTime;


    }
    /*void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }*/
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
        bullet.damage = damage;
        if (bullet != null)
        {
            bullet.Seek(target, targetObj);
        }

    }
    void OnMouseDown()
    {
        updateTowers.DrawRange(number);
    }
    public int PowerThisTower()
    {
        int k = 0;
        GameObject[] tochki = GameObject.FindGameObjectsWithTag("road");
        foreach (GameObject tochka in tochki)
        {
            float distanceToTochka = Vector3.Distance(new Vector3(transform.position.x, transform.position.y, 0f), new Vector3(tochka.transform.position.x, tochka.transform.position.y, 0f));
            if (distanceToTochka <= range) { k++; }
        }
        int power = (int)Mathf.Round(((k-6)%61/15+1)*damage*(1f/reload)/10); //(k-6) -"количество точек" (damage*(1f/reload)) - урон в секунду деление на 10 чтобы наладить размерность
        return power;
    }

}
