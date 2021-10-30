using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Rotate());
    }
    public Vector3 rot;
    //public const Vector3 v = new Vector3(0, 1, 0);
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            StartCoroutine(Rotate());
        }

    }

    IEnumerator Rotate()
    {
        for (float a = 0f; a < 360; a += 0.1f)
        {
            transform.Rotate(0, 0, -a);
            yield return new WaitForSeconds(0.05f);
        }
    }

}
