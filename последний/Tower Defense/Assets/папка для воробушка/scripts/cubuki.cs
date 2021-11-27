using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubuki : MonoBehaviour
{
    private GameObject upTower;
    private int number;
    private UpdateTower NewTowerInOurParty;
    public Color hoverColor;
    public Color NoColor;
    private SpriteRenderer rend;
    private money money;
    public GameObject turret;
    public GameObject TBM;
    private Color startColor;
    public GameObject ST;
    public GameObject[] platformA;
    public GameObject[] platformB;
    public int k = 1;
    public int allSpendedMoney = 0;
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
        money.earnMoney(-turret.GetComponent<tower>().cost);
        var _turret=(GameObject)Instantiate(turret, transform.position-new Vector3(0,0,0.1f), transform.rotation);
        number = NewTowerInOurParty.numberTower;
        _turret.GetComponent<tower>().number = number;
        NewTowerInOurParty.PullTowers(_turret,this);
        allSpendedMoney += _turret.GetComponent<tower>().cost;
    }
    public void UpgradeTower() 
    {
        switch (turret.name)
        {
            case "PlatformB":
                Destroy(NewTowerInOurParty.towers[number]);
                var _turret = (GameObject)Instantiate(platformB[k], transform.position - new Vector3(0, 0, 0.00000001f), transform.rotation);
                _turret.GetComponent<tower>().number = number;
                NewTowerInOurParty.towers[number] = _turret;
                NewTowerInOurParty.DrawRange(number);
                k += 1;
                break;
            case "PlatformA1":
                Destroy(NewTowerInOurParty.towers[number]);
                var _turretA = (GameObject)Instantiate(platformA[k], transform.position - new Vector3(0, 0, 0.00000001f), transform.rotation);
                _turretA.GetComponent<tower>().number = number;
                NewTowerInOurParty.towers[number] = _turretA;
                NewTowerInOurParty.DrawRange(number);
                k += 1;
                break;
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        upTower = GameObject.Find("TowerUpgrade");
        NewTowerInOurParty = upTower.GetComponent<UpdateTower>();
        money = GameObject.FindWithTag("money").GetComponent<money>();
        rend = GetComponent<SpriteRenderer>();
        startColor = rend.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
