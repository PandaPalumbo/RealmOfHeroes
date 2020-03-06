﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Hero: MonoBehaviour
{

    //attributes
    public string name;
    public int gameSpeed;
    public int actionPoints;
    private int originalAP;
    public int maxHp;
    public int currentHp;

    //movement
    public bool canMove;
    public bool isSelected;
    private int moveSpeed;
    private int gameSpeedLeft;
    private int x;
    private int y;
    public BaseGrid baseGrid;
    public Grid grid;
    public Vector3 originalPos;
    private float distanceTravelled;

    Vector2 movement;

    //playe sprites
    public SpriteRenderer spriteRenderer;
    public Material outlineMaterial;
    public Material defaultMaterial;
    public Sprite lookUp;
    public Sprite lookDown;
    public Sprite lookRight;
    public Sprite lookLeft;
    public Sprite movementAreaTile;
    public Sprite spriteMap;
    private Material material;
    private bool isSelectMat;

    public void Start()
    {
        //set objects and variables
        grid = baseGrid.grid;
        moveSpeed = gameSpeed / 5;
        originalAP = actionPoints;
  
    }

    private void Update()
    {
        if (isSelected)
        {
            PlayerRotation();
            MoveToMouse();
            if(GameObject.Find("SpawnSprite") == null)
            {               
                SpawnSelectedTile();               
            }
        }
        else
        {
            spriteRenderer.material = defaultMaterial;
            if (GameObject.Find("SpawnSprite") != null)
            {
                DestroyObject(GameObject.Find("SpawnSprite"));
            }
        }
    }


    private void SpawnSelectedTile()
    {
        UtilsClass.CreateWorldSprite(
                    "SpawnSprite",
                    movementAreaTile, //sprite
                    new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), // pos
                    new Vector3(1, 1, 0), // scale
                    1, //order
                    new Color(239, 255, 139, 0.3f) // color
                );
    }

    private void PlayerRotation()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                spriteRenderer.sprite = lookLeft;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                spriteRenderer.sprite = lookRight;

            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                spriteRenderer.sprite = lookDown;
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                spriteRenderer.sprite = lookUp;
            }
        }
        
    }

    private void MoveToMouse()
    {
        //EnableMovement()
        if (canMove)
        {

            if (Input.GetMouseButtonDown(0))
            {
                
                Vector3 mousePos = UtilsClass.GetMouseWorldPosition();
                mousePos.x = mousePos.x > 0 ? Mathf.Floor(mousePos.x + .5f) : Mathf.Ceil(mousePos.x + .5f);
                mousePos.y = mousePos.y > 0 ? Mathf.Floor(mousePos.y) + 1 : Mathf.Ceil(mousePos.y) + 1;
                mousePos.z = 0;
                Debug.Log(mousePos);
                //
                bool xLimits = Mathf.Abs(Mathf.Abs(mousePos.x) - Mathf.Abs(originalPos.x)) <= moveSpeed;
                bool yLimits = Mathf.Abs(Mathf.Abs(mousePos.y) - Mathf.Abs(originalPos.y)) <= moveSpeed;
                //Debug.Log("X Mag: " + (Mathf.Abs(mousePos.x) - Mathf.Abs(originalPos.x)) );
                //Debug.Log("Y Mag: " + (Mathf.Abs(mousePos.y) - Mathf.Abs(originalPos.y)));
                if (yLimits && xLimits)
                {
                    distanceTravelled = Mathf.Floor( Vector3.Distance(mousePos, originalPos));
                    Debug.Log("dist travelled: " +distanceTravelled);
                    transform.position = mousePos;
                }

            }
        }        
    }

    public void OnSelect() {
        
    }

    //enables movement and shows player possible tiles they can move to. 
    public void EnableMovement()
    {
        if (isSelected)
        {
            if (canMove == false)
            {
                originalPos = transform.position;
                UtilsClass.CreateWorldSprite(
                    "MovementArea",
                    movementAreaTile, //sprite
                    new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), // pos
                    new Vector3((moveSpeed + 0.5f) * 2, ((moveSpeed) * 2) + 1, 0), // scale
                    1, //order
                    new Color(0, 0, 139, 0.3f) // color
                );
                canMove = true;
            }
            //UtilsClass.CreateWorldSprite(string name, Sprite sprite, Vector3 position, Vector3 localPosition, Vector3 localScale, int sortingOrder, Color color)
        }
    }

    public void  DisableMovement()
    {
        if (canMove == true)
        {
            EndMovement();
            moveSpeed = 0;
            Debug.Log("Move Speed: " + moveSpeed);
        }

    }

    public void EndMovement()
    {
        GameObject movementArea = GameObject.Find("MovementArea");
        DestroyObject(movementArea);
        canMove = false;
    }

    public void GetXY(Vector3 mousePos, out int x, out int y)
    {
        x = Mathf.FloorToInt((mousePos - transform.position).x / grid.cellSize);
        y = Mathf.FloorToInt((mousePos - transform.position).y / grid.cellSize);
    }

    public void Reset()
    {
        moveSpeed = gameSpeed / 5;
        actionPoints = originalAP;
    }
}
