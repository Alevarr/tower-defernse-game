using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showScreemer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<AudioSource>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.waypointIndex == 6)
        {
            Show();
        }
    }

    void Show()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<AudioSource>().enabled = true;
    }
}
