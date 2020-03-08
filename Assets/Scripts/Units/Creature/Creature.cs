using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{


    //attributes
    public string name;
    public string title;
    public string description;
    public ECreatureTypes creatureType;
    public EHumanoidRaces humanoidRace;
    public List<EDamageType> resistances;
    public List<EDamageType> vulnerabilities;
    public List<EDamageType> immunities;
    public int level;
    public int actionPoints;
    public int gameSpeed;
    private int originalAP;
    public int strength;
    public int dexterity;
    public int constitution;
    public int intelligence;
    public int wisdom;
    public int charisma;
    public float maxHp;
    public float currentHp;
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
        if(creatureType != ECreatureTypes.HUMANOID)
        {
            humanoidRace = EHumanoidRaces.NONE;
        }
    }
    public void Update()
    {
        CapHealth();
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Kill()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int damageDone, EDamageType damageType)
    {
        if (immunities.Contains(damageType))
        {
            //do immune message!
        } else if (resistances.Contains(damageType))
        {
            currentHp = currentHp - Mathf.FloorToInt((damageDone * 0.5f));
            //do resistant message
        } else if (vulnerabilities.Contains(damageType))
        {
            currentHp = currentHp - Mathf.FloorToInt((damageDone * 2));
        }
        else
        {
            currentHp = currentHp - damageDone;
            Debug.Log(name + " has " + currentHp+ " HP left");

        }
    }
    public void TakeHeal(int healAmount)
    {
        currentHp = currentHp + healAmount;
    }

    public void TakeBuff(int buffAmount, ECreatureAttributes creatureAttributes)
    {
        if(creatureAttributes == ECreatureAttributes.charisma)
        {
            charisma += buffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.constitution)
        {
            constitution += buffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.dexterity)
        {
            dexterity += dexterity;
        }
        if (creatureAttributes == ECreatureAttributes.gameSpeed)
        {
            gameSpeed += buffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.intelligence)
        {
            intelligence += buffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.maxHp)
        {
            maxHp += buffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.originalAP)
        {
            originalAP += buffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.strength)
        {
            strength += buffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.wisdom)
        {
            wisdom += buffAmount;
        }
    }
    public void TakeDebuff(int debuffAmount, ECreatureAttributes creatureAttributes)
    {
        if (creatureAttributes == ECreatureAttributes.charisma)
        {
            charisma -= debuffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.constitution)
        {
            constitution -= debuffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.dexterity)
        {
            dexterity -= dexterity;
        }
        if (creatureAttributes == ECreatureAttributes.gameSpeed)
        {
            gameSpeed -= debuffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.intelligence)
        {
            intelligence -= debuffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.maxHp)
        {
            maxHp -= debuffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.originalAP)
        {
            originalAP -= debuffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.strength)
        {
            strength -= debuffAmount;
        }
        if (creatureAttributes == ECreatureAttributes.wisdom)
        {
            wisdom -= debuffAmount;
        }
    }

    public void CapHealth()
    {
        if(currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }
}
