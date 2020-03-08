using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public Creature heroCreature;
    public BaseHeroClass heroClass;
    public EHeroClass heroClassName;
    public Ability[] abilities;
    public AbilityHandler abilityHandler;
    public int[] spellSlots;
    private int maxHeroLevel = 20;

    // Start is called before the first frame update
    void Start()
    {
        getHeroClass();
        Debug.Log(heroClass.ClassDescription);
        GetSpellSlots(heroCreature.level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getHeroClass()
    {
        if(heroClassName == EHeroClass.Monk)
        {
            heroClass = new BaseMonkClass(heroCreature, heroCreature.level);
        }
        else
        {
            heroClass = new BaseWizardClass(heroCreature, heroCreature.level);
        }
    }

    void GetSpellSlots(int classLevel)
    {
        for(int i = 0; i > classLevel - 1; i++)
        {
            if (classLevel == 1)
            {
                spellSlots[i] = 4;
            }
            if (classLevel > 1 && classLevel - 1 % 2 == 0 && classLevel < 10)
            {
                spellSlots[i] = 3;
            }
            if (classLevel > 1 && classLevel - 1 % 2 == 0 && classLevel < 15)
            {
                spellSlots[i] = 2;
            }
            if (classLevel > 1 && classLevel - 1 % 2 == 0 && classLevel < 20)
            {
                spellSlots[i] = 1;
            }
        }

    }
}
