using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    private GameObject targetObject;
    public float speed=10f;
    public float damage=25f;


    public void Seek(Transform Target,GameObject objectTarget) 
    {
        target = Target;
        targetObject = objectTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    void HitTarget() 
    {
        var enemy = targetObject.GetComponent<enemy>();
        if (enemy)
        {
            enemy.TakeHit(damage);
        }
        Destroy(gameObject);
    }
}
