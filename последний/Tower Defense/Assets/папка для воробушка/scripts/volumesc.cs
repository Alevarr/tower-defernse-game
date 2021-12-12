using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumesc : MonoBehaviour
{
    public Sprite[] ChangeVolume;
    private int n = 0;
    public AudioSource music;
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
        gameObject.GetComponent<SpriteRenderer>().sprite = ChangeVolume[n];
        print("а че а всм");
        if (n == 0) { music.Play(); } else { music.Pause(); }
        
    }
}