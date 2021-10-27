using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButtonManager : MonoBehaviour
{
    towerbutton towerBtnPressed;
    public GameObject SelectedTowerObj;
    
    public void SelectedTower(towerbutton towerSelected) 
    {
        towerBtnPressed = towerSelected;
        SelectedTowerObj = towerBtnPressed.TowerObject;
    }
}
