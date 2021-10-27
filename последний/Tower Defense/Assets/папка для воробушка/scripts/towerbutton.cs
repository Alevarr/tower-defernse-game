using UnityEngine;

public class towerbutton : MonoBehaviour
{
    [SerializeField]
    GameObject towerObject;
    public GameObject TowerObject 
    {
        get 
        {
            return towerObject;
        }
    }
}