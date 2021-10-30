using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class money : MonoBehaviour
{
    public Text moneyText;
    public int moneyint;
    void Start()
    {
        moneyText.text = moneyint + "$";
    }
    public void earnMoney(int pay) 
    {
        moneyint += pay;
        moneyText.text = moneyint + "$";
    }
    
}
