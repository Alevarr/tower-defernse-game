using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSpawnPoint : MonoBehaviour
{
    public Transform FinishPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(FinishPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
