using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateTower : MonoBehaviour
{
    public List <GameObject> towers = new List <GameObject>();
    public List <cubuki> cubiks = new List <cubuki>();
    public GameObject SelectedTowerOnScene;
    public GameObject pass;
    public ui powertower;
    public int numberTower = 0;
    public int k = 0;
    public int beforeNumberTower = 0;
    private money money;
    private GameObject rC;
    private int decidedTower;
    private GameObject delete;
    private GameObject upgrade;
    private int upgradecost=0;
    
    

    // Start is called before the first frame update
    void Start()
    {
        money = GameObject.FindWithTag("money").GetComponent<money>();
        rC = pass;
        delete= GameObject.Find("delete");
        upgrade= GameObject.Find("upgrade");
        delete.SetActive(false);
        upgrade.SetActive(false);


    }
    public void PullTowers(GameObject x, cubuki y) 
    {
        cubiks.Add(y);
        towers.Add(x);
        numberTower += 1;
    }
    public void DrawRange(int number)
    {
        decidedTower = number;
        upgradecost = towers[number].GetComponent<tower>().upgradeCost;
        if (rC != null) { rC.SetActive(false); }
        if (rC != towers[number].GetComponent<tower>().rangeCircle || k==1)
        {
            rC = towers[number].GetComponent<tower>().rangeCircle;
            rC.SetActive(true);
            k = 0;
            UpdateButtons();
            
        }
        else 
        {
            k += 1;
            delete.SetActive(false);
            upgrade.SetActive(false);
        }
    }
    public void Upgrade()
    {
        tower tower = towers[decidedTower].GetComponent<tower>();
        if (cubiks[decidedTower].k == 10) { return; }

        if (money.moneyint >= upgradecost)
        {
            powertower = GameObject.Find("allUI").GetComponent<ui>();
            powertower.UpdateTowerPower(-towers[decidedTower].GetComponent<tower>().PowerThisTower());
            money.earnMoney(-upgradecost);
            cubiks[decidedTower].allSpendedMoney += upgradecost;
            cubiks[decidedTower].UpgradeTower();
            upgradecost = towers[decidedTower].GetComponent<tower>().upgradeCost;
           
            UpdateButtons();

            if (cubiks[decidedTower].k == 10) { GameObject.Find("upgradeText").GetComponent<Text>().text = "MAX"; GameObject.Find("upgradeText (1)").GetComponent<Text>().text = ""; }
            
        }
    }
    public void DeleteTower()
    {
        powertower = GameObject.Find("allUI").GetComponent<ui>();
        powertower.UpdateTowerPower(-towers[decidedTower].GetComponent<tower>().PowerThisTower());
        money.earnMoney(cubiks[decidedTower].allSpendedMoney / 2);
        cubiks[decidedTower].turret = null;
        Destroy(towers[decidedTower]);
        delete.SetActive(false);
        upgrade.SetActive(false);
        cubiks[decidedTower].allSpendedMoney = 0;
        cubiks[decidedTower].k = 1;

    }
    public void UpdateButtons() 
    {
        delete.SetActive(true);
        GameObject.Find("deleteText").GetComponent<Text>().text = "delete +" + cubiks[decidedTower].allSpendedMoney/2 + "$";
        upgrade.SetActive(true);
        if (cubiks[decidedTower].k != 10) 
        {
            GameObject.Find("upgradeText").GetComponent<Text>().text = "upgrade -" + upgradecost + "$";
            GameObject.Find("upgradeText (1)").GetComponent<Text>().text = towers[decidedTower].GetComponent<tower>().comentUpgrade;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
