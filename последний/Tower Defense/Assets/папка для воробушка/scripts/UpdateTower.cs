using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTower : MonoBehaviour
{
    public List <GameObject> towers = new List <GameObject>();
    public GameObject SelectedTowerOnScene;
    public GameObject pass;
    public int numberTower = 0;
    public int k = 0;
    public int beforeNumberTower = 0;
    private GameObject rC;
    // Start is called before the first frame update
    void Start()
    {
        rC = pass;
    }
    public void PullTowers(GameObject x) 
    {
        towers.Add(x);
        numberTower += 1;
    }
    public void DrawRange(int number)
    {
        rC.SetActive(false);
        if (rC != towers[number].GetComponent<tower>().rangeCircle || k==1)
        {
            rC = towers[number].GetComponent<tower>().rangeCircle;
            rC.SetActive(true);
            k = 0;
        }
        else 
        {
            k += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
