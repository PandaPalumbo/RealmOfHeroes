using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, ICreature, IDamagable, IKillable
{
    public string name { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public ECreatureTypes creatureType { get; set; }
    public EHumanoidRaces humanoidRace { get; set; }
    public int level { get; set; }
    public int actionPoints { get; set; }
    public int gameSpeed { get; set; }
    public int originalAP { get; set; }
    public int strength { get; set; }
    public int dexterity { get; set; }
    public int constitution { get; set; }
    public int intelligence { get; set; }
    public int wisdom { get; set; }
    public int charisma { get; set; }
    public float maxHp { get; set; }
    public float currentHp { get; set; }

    //attributes
    public string _name;
    public string _title;
    public string _description;
    public ECreatureTypes _creatureType;
    public EHumanoidRaces _humanoidRace;
    public int _level;
    public int _actionPoints;
    public int _gameSpeed;
    private int _originalAP;
    public int _strength;
    public int _dexterity;
    public int _constitution;
    public int _intelligence;
    public int _wisdom;
    public int _charisma;
    public float _maxHp;
    public float _currentHp;
    public bool isSelected;

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
        name = _name;
        title = _title;
        description = _description;
        creatureType = _creatureType;
        humanoidRace = _humanoidRace;
        level = _level;
        actionPoints = _actionPoints;       
        _originalAP = actionPoints;
        originalAP = _originalAP;
        gameSpeed = _gameSpeed;
        strength = _strength;
        dexterity = _dexterity;
        constitution = _constitution;
        intelligence = _intelligence;
        wisdom = _wisdom;
        charisma = _charisma;
        maxHp = _maxHp;
        currentHp = _currentHp;

        if(creatureType != ECreatureTypes.HUMANOID)
        {
            humanoidRace = EHumanoidRaces.NONE;
        }
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Kill()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage<T>(T damageTaken)
    {
        throw new System.NotImplementedException();
    }
}
