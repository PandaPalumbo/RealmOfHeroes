using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class BaseGrid: MonoBehaviour
{
    public int width;
    public int height;
    public int cellSize;
    public Vector3 origin;
    public Grid grid;
    public Sprite gridLineSprite;

    private void Start()
    {
        grid = new Grid(width, height, cellSize, origin);


        //for (int x = 0; x > 100; x++)
        //{
        //    for (int y = 0; y > 100; y++)
        //    {
        //        UtilsClass.CreateWorldSprite(
        //            "MovementArea",
        //            gridLineSprite, //sprite
        //            new Vector3(transform.position.x, transform.position.y, 0), // pos
        //            new Vector3(10000, 1 / 16, 0), // scale
        //            1, //order
        //            new Color(0, 0, 0, 0f) // color
        //        );

        //        UtilsClass.CreateWorldSprite(
        //            "MovementArea",
        //            gridLineSprite, //sprite
        //            new Vector3(transform.position.x, transform.position.y, 0), // pos
        //            new Vector3(1 / 16, 10000, 0), // scale
        //            1, //order
        //            new Color(0, 0, 0, 0f) // color
        //        );
        //    }
        //}

    }
  
}
