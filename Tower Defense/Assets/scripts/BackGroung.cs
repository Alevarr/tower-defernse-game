using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackGroung : MonoBehaviour
{
    public Tilemap tilemapback;
    public Tilemap tilemapRoad;

    public Tile free;
    public Tile close;
    public Tile up;
    public Tile down ;
    public Tile right;
    public Tile[] back;
    public int sizeBackX;
    public int sizeBackY;
    private int x = 0;
    private int y = 0;
    // Start is called before the first frame update
    void Start()
    {
        //tilemap.SetTile(new Vector3Int(0, 0, 0), free);
        for (int i = 0; i < sizeBackY; i++)
        {
            for (int j = 0; j < sizeBackX; j++)
            {
                tilemapback.SetTile(new Vector3Int(j, i, 0), back[Random.Range(0,back.Length)]);
            }
        }
        int beg = 1;
        int end = 4;
        y = Random.Range(3, 7);
        while (x < sizeBackX && y < sizeBackY && y > 0)
        {
            int rnd = Random.Range(beg, end);
            switch (rnd) 
            {
                case 1:
                    tilemapRoad.SetTile(new Vector3Int(x, y, 0), up);
                    y++;
                    beg = 1;
                    end = 3;
                    break; 
                case 2:
                    tilemapRoad.SetTile(new Vector3Int(x, y, 0), right);
                    x++;
                    beg = 1;
                    end = 4;
                    break;
                case 3:
                    tilemapRoad.SetTile(new Vector3Int(x, y, 0), down);
                    y--;
                    beg = 2;
                    end = 4;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
