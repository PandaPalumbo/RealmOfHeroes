using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Mechanics : MonoBehaviour
{
    public int numberOfHeros;
    public BaseGrid baseGrid;
    public Grid grid;
    public Sprite mouseOverTile;
    private Hero[] heros;
    private Monster[] monsters;
    private Hero selectedHero;
    private Monster selectedMonster;
    private Vector3 mousePos;
    private bool mouseTileExists;
    private SpriteRenderer mouseOverSR;

    public bool isHeroesTurn;
    public bool isMonstersTurn;

    //UI
    public bool isHoverOverButton;
    public GameObject encounterPanel;
    private bool isEncounterPanelOpen;
    public GameObject moveButton;
    public GameObject inMovementButtons;
    public GameObject alertText;
    public GameObject endTurn;
    public UnityEngine.UI.Image currentHP;
    public UnityEngine.UI.Text characterName;
    public GameObject characterFrame;

    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        isHeroesTurn = true;
        isMonstersTurn = false;
        baseGrid = FindObjectOfType<BaseGrid>();
        heros = FindObjectsOfType<Hero>();
        monsters = FindObjectsOfType<Monster>();
        numberOfHeros = heros.Length;
        mouseTileExists = false;
        isEncounterPanelOpen = false;
        Debug.Log("how many heroes: " + heros.Length);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = UtilsClass.GetMouseWorldPosition();
        MouseOverTile(mousePos);
        HandleMovement();
        setAlertText();
        MoveCamera();
        
    }

    private void HandleMovement()
    {
        if ((selectedHero == null || selectedHero.canMove == false) && isHeroesTurn)
        {
            SelectHero();
        }
        if ((selectedMonster == null || selectedMonster.canMove == false) && isMonstersTurn)
        {
            SelectMonster();
        }
    }

    //creates the hover over sprite on the grid that folows mouse
    private void MouseOverTile(Vector3 mousePosFn)
    {
        int x, y;
        GetXY(mousePosFn, out x, out y);
        Vector3 tilePos = new Vector3(x, y + 0.5f, 0);
        if (mouseTileExists)
        {
            var tempTile = GameObject.Find("MouseOverTile");
            if(tempTile.transform.position != tilePos)
            {
                DestroyObject(tempTile);
                UtilsClass.CreateWorldSprite(
                    "MouseOverTile",
                    mouseOverTile, //sprite
                    tilePos, // pos
                    new Vector3(.9f, .9f, 1), // scale
                    1, //order
                    new Color(0, 0, 0, 0.5f) // color
                );
                mouseTileExists = true;
            } else
            {
                if (Input.GetMouseButton(0))
                {
                    SpriteRenderer tempSR = tempTile.GetComponent<SpriteRenderer>();
                    tempSR.color = new Color(1, 1, 1, 0.5f);
                } else
                {
                    SpriteRenderer tempSR = tempTile.GetComponent<SpriteRenderer>();
                    tempSR.color = new Color(0, 0, 0, 0.5f);
                }
            }
        }    
        else
        {

            UtilsClass.CreateWorldSprite(
                    "MouseOverTile",
                    mouseOverTile, //sprite
                    tilePos, // pos
                    new Vector3(.9f, .9f, 1), // scale
                    1, //order
                    new Color(0, 0, 0, 0.5f) // color
                );
            mouseTileExists = true;
        }   
    }

    // gets the baseGrid coordinates based off of mouse pos
    public void GetXY(Vector3 mousePos, out int x, out int y)
    {
        x = Mathf.FloorToInt((mousePos - baseGrid.origin).x );
        y = Mathf.FloorToInt((mousePos - baseGrid.origin).y );
    }

    // allows hero to be selected
    public void SelectHero()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            int x, y;
            GetXY(mousePos, out x, out y);
            //Debug.Log("X clicked: " + x + "Y clicked:" + y);
            if (isHoverOverButton == false)
            {
                foreach (Hero hero in heros)
                {
                    if (hero.transform.position.y - 1f == y && hero.transform.position.x == x)
                    {
                        if(hero != selectedHero)
                        {
                            HideObject(characterFrame);
                            HideObject(encounterPanel);
                            if (selectedHero != null)
                            {
                                selectedHero.isSelected = false;
                            }
                            selectedHero = hero;
                            selectedHero.isSelected = true;
                            ShowObject(encounterPanel);
                            ShowObject(characterFrame);
                            SetCurrentHP();
                            SetCharacterName();
                            break;
                        }
                    }
                    else
                    {
                        HideObject(encounterPanel);
                        HideObject(characterFrame);
                        if (selectedHero != null)
                        {
                            selectedHero.isSelected = false;
                        }
                        selectedHero = null;
                    }
                }
            }
            
        }
    }

    // allows player to be selected
    public void SelectMonster()
    {

        if (Input.GetMouseButtonDown(0))
        {

            int x, y;
            GetXY(mousePos, out x, out y);
            //Debug.Log("X clicked: " + x + "Y clicked:" + y);
            if (isHoverOverButton == false)
            {
                foreach (Monster monster in monsters)
                {
                    if (monster.transform.position.y - 1f == y && monster.transform.position.x == x)
                    {
                        if (monster != selectedMonster)
                        {
                            HideObject(characterFrame);
                            HideObject(encounterPanel);
                            if(selectedMonster != null)
                            {
                                selectedMonster.isSelected = false;
                            }
                            selectedMonster = monster;
                            selectedMonster.isSelected = true;
                            ShowObject(encounterPanel);
                            ShowObject(characterFrame);
                            SetCurrentHP();
                            SetCharacterName();
                            break;
                        }
                    }
                    else
                    {
                        HideObject(encounterPanel);
                        HideObject(characterFrame);
                        if (selectedMonster != null)
                        {
                            selectedMonster.isSelected = false;
                        }
                        selectedMonster = null;
                    }
                }
            }

        }
    }

    private void HideObject(GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    private void ShowObject(GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void IsHoverOverButton()
    {
        isHoverOverButton = true;
    }

    public void IsHoverNotOverButton()
    {
        isHoverOverButton = false;
    }

    public void CancelMoveButton()
    {
        ShowObject(encounterPanel);
        ShowObject(endTurn);
        selectedHero.transform.position = selectedHero.originalPos;
        selectedHero.EndMovement();
        HideObject(inMovementButtons);
    }

    public void MoveButton()
    {
        if (isHeroesTurn)
        {
            selectedHero.EnableMovement();
        } else if (isMonstersTurn) {
            selectedMonster.EnableMovement();
        }
        

        HideObject(encounterPanel);
        ShowObject(inMovementButtons);

        HideObject(endTurn);
        
        isHoverOverButton = false;
    }
    
    public void ConfirmMoveButton()
    {
        if (isHeroesTurn)
        { 
            selectedHero.DisableMovement();
        }
        else if (isMonstersTurn)
        {
            selectedMonster.DisableMovement();
        }
        
        ShowObject(encounterPanel);
        ShowObject(endTurn);
        HideObject(inMovementButtons);
    }

    public void EndTurnButton()
    {
        HideObject(encounterPanel);
        if (isHeroesTurn)
        {
            if(selectedHero != null)
            {
                selectedHero.isSelected = false;
            }
            
            isHeroesTurn = false;
            isMonstersTurn = true;
            foreach(Hero hero in heros)
            {
                hero.Reset();
            }
            
        }
        else
        {
            if (selectedMonster != null)
            {
                selectedMonster.isSelected = false;
            }
            isMonstersTurn = false;
            isHeroesTurn = true;
            foreach (Monster monster in monsters)
            {
                monster.Reset();
            }

        }
        
    }

    public void isPlayerRoundOver()
    {
        if (isHeroesTurn)
        {
            List<bool> allHeroesAP = new List<bool>();
            foreach(Hero hero in heros)
            {
                if(hero.actionPoints == 0)
                {
                    allHeroesAP.Add(true);
                }
                if(allHeroesAP.Count == heros.Length)
                {
                    EndTurnButton();
                }
            }
        } else if (isMonstersTurn)
        {
            List<bool> allMonstersAP = new List<bool>();
            foreach (Monster monster in monsters)
            {
                if (monster.actionPoints == 0)
                {
                    allMonstersAP.Add(true);
                }
                if (allMonstersAP.Count == heros.Length)
                {
                    EndTurnButton();
                }
            }
        }
    }

    public void setAlertText()
    {
        if (isHeroesTurn)
        {
            alertText.GetComponent<UnityEngine.UI.Text>().text = "Heroes Turn!";
        } else
        {
            alertText.GetComponent<UnityEngine.UI.Text>().text = "Monsters Turn!";
        }
        
    }

    public void MoveCamera()
    {
        if((selectedHero==null ||!selectedHero.canMove) && (selectedMonster == null || !selectedMonster.canMove)){
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1){
                camera.transform.position = new Vector3((camera.transform.position.x + Input.GetAxisRaw("Horizontal") * 0.5f), camera.transform.position.y, camera.transform.position.z);
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                camera.transform.position = new Vector3(camera.transform.position.x, (camera.transform.position.y + Input.GetAxisRaw("Vertical") * 0.5f), camera.transform.position.z);
            }
        }
    }

    public void SetCharacterName()
    {
        if (selectedHero != null)
        {
            characterName.text = selectedHero.name;
        }
        if (selectedMonster != null)
        {
            characterName.text = selectedMonster.name;
        }
    }
    public void SetCurrentHP()
    {
        if(selectedHero != null)
        {

            currentHP.transform.localScale = new Vector3(currentHP.transform.localScale.x * (selectedHero.currentHp/selectedHero.maxHp), currentHP.transform.localScale.y, currentHP.transform.localScale.z);
        }
        if (selectedMonster != null)
        {
            currentHP.transform.localScale = new Vector3(currentHP.transform.localScale.x * (selectedMonster.currentHp / selectedMonster.maxHp), currentHP.transform.localScale.y, currentHP.transform.localScale.z);

        }
    }
}
