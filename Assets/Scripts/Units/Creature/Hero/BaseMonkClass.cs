using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonkClass: BaseHeroClass
{
    public BaseMonkClass(Creature creature, int classLevel)
    {
        CharacterClassName = EHeroClass.Monk;
        ClassDescription = "A strong martial hero, guided by powers found within themself";
        Creature = creature;
        ClassLevel = classLevel;
    }
}
