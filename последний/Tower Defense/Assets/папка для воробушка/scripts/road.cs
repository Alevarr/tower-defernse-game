using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class road : MonoBehaviour
{
    public GameObject tochka;// ->"."
    public float offset;
    private float x;
    private float y;
    //хахахахаха даже у дороги есть скрипт,получается smartRoad или же если говорить на богатом то IRoad 12 Max Pro
    void Start()
    {
        if (transform.eulerAngles.z == 90) 
        {
            var a = transform.localScale.x;
            var b = transform.localScale.y;
            transform.localScale = new Vector3(b,a, transform.localScale.z);
            transform.eulerAngles = new Vector3(0,0,0);
        }
        if (transform.localScale.x > transform.localScale.y)
        {
            x = transform.position.x - (transform.localScale.x / 2f)+offset+ transform.localScale.y / 2f;
            y = transform.position.y;
        }
        else 
        {
            x = transform.position.x;
            y = transform.position.y - (transform.localScale.y / 2f)+offset+ transform.localScale.x / 2f;
            
        }
        MakeRoadSmart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MakeRoadSmart() 
    {
        if (transform.localScale.x > transform.localScale.y)
        {
            while (x < transform.position.x + (transform.localScale.x / 2f) - transform.localScale.y / 2f)
            {
                Instantiate(tochka, new Vector3(x, y, transform.position.z), transform.rotation);
                x += offset;
            }
        }
        else 
        {
            while (y < transform.position.y + (transform.localScale.y / 2f))
            {
                Instantiate(tochka, new Vector3(x, y, transform.position.z), transform.rotation);
                y += offset;
            }
        }
    }
}
