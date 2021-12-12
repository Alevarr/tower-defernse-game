using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerSC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GiveMeMoooore()
    {
        SceneManager.LoadScene(0);
    }
    public void VipustiteMenyaaaaa() 
    {
        Application.Quit();
    }
    public void Pognaly() 
    {
        SceneManager.LoadScene(1);
    }
}
