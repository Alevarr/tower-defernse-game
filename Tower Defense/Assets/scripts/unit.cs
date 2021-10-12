using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    public Vector3 pos;
    [SerializeField] 
    private float tilesize;
    public float speed;
    public Vector3 direction=new Vector3 (0,0,0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        pos += speed * Time.deltaTime * direction;
        transform.position=pos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "left":
                direction = new Vector3(-1, 0, 0);
                break;
            case "right":
                direction = new Vector3(1, 0, 0);
                break;
            case "up":
                direction = new Vector3(0, 1, 0);
                break;
            case "down":
                direction = new Vector3(0, -1, 0);
                break;



        }
    }
}
