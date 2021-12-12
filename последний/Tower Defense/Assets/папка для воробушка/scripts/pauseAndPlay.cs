using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseAndPlay : MonoBehaviour
{
    public Sprite[] ChangeIcon;
    private int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        n = Mathf.Abs(n - 1);
        gameObject.GetComponent<SpriteRenderer>().sprite = ChangeIcon[n];
        if (n == 0) { Time.timeScale = 0; } else { Time.timeScale = 1; }

    }
}
