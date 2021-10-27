using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubuki : MonoBehaviour
{
    public Color hoverColor;
    private SpriteRenderer rend;
    private GameObject turret;
    public GameObject TBM;
    private Color startColor;
    void OnMouseEnter()
    {
        rend.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.color = startColor;
    }
    void OnMouseDown()
    {
        if (turret != null) 
        {
            print("NO");
            return;
        }
        turret = TBM.GetComponent<TowerButtonManager>().SelectedTowerObj;
        Instantiate(turret, transform.position, transform.rotation);
    }
        // Start is called before the first frame update
        void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
