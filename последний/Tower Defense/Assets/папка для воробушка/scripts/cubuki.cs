using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubuki : MonoBehaviour
{
    public Color hoverColor;
    public Color NoColor;
    private SpriteRenderer rend;
    private money money;
    private GameObject turret;
    public GameObject TBM;
    private Color startColor;
    public GameObject ST;
    void OnMouseOver()
    {
        if (TBM.GetComponent<TowerButtonManager>().SelectedTowerObj!=null)
        {
            ST = TBM.GetComponent<TowerButtonManager>().SelectedTowerObj;
            if (money.moneyint >= ST.GetComponent<tower>().cost)
            { rend.color = hoverColor; }
            else
            {
                rend.color = NoColor;
            }
        }
    }
    void OnMouseExit()
    {
        rend.color = startColor;
    }
    void OnMouseDown()
    {
        if (turret != null || TBM.GetComponent<TowerButtonManager>().SelectedTowerObj == null || money.moneyint < ST.GetComponent<tower>().cost) 
        {
            return;
        }
        turret = TBM.GetComponent<TowerButtonManager>().SelectedTowerObj;
        Instantiate(turret, transform.position, transform.rotation);
        money.earnMoney(-turret.GetComponent<tower>().cost);
    }
        // Start is called before the first frame update
        void Start()
    {
        money = GameObject.FindWithTag("money").GetComponent<money>();
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
