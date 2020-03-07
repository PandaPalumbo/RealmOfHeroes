using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWizardClass: BaseHeroClass
{
    public BaseWizardClass(Creature creature, int classLevel)
    {
        CharacterClassName = EHeroClass.Wizard;
        ClassDescription = "A strong martial hero, guided by powers found within books";
        Creature = creature;
        ClassLevel = classLevel;
    }
}
