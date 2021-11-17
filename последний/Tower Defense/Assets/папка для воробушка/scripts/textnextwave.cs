using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textnextwave : MonoBehaviour
{
    [SerializeField]
    private Text textnextwavetext;
    public float textCooldown=0f;
    private GameObject nextWave;
    
    // Start is called before the first frame update
    void Start()
    {
        nextWave = GameObject.Find("nextwave");
    }

    // Update is called once per frame
    void Update()
    {
        if (textCooldown !=5f && textCooldown != 7f)
        {
            textnextwavetext.text = Mathf.Round(textCooldown).ToString();
            nextWave.SetActive(false);
        }
        else 
        {
            textnextwavetext.text="";
            nextWave.SetActive(true);
        }
    }
}
