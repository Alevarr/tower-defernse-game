using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cube : MonoBehaviour
{
    public float speed;
    public float speedrot;
    public float a;
    private Vector3 pos;
    private bool K;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos += speed * Time.deltaTime * new Vector3(-1f, 0f, 0f);
        speed += a * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) && pos.z > -4.40f)
        {
            pos += new Vector3(0, 0, -1f) * speedrot * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && pos.z<4.45f)
        {
            pos += new Vector3(0, 0, 1f) * speedrot * Time.deltaTime;
        }
        transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "finish")
        {
            K = true;
            print("ËÀÁÓ ÈÄÈ ÄÅËÀÒÜ ÅÁËÀÍ!!!");
        }
        else
        {
            if (K != true)
            {
                SceneManager.LoadScene(0);
                print("You loser");
            } 
        }
    }
}
