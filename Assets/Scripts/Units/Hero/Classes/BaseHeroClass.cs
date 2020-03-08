using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHeroClass 
{
    private EHeroClass className;
    private string classDescription;
    public Creature creature;
    public int classLevel;

    public EHeroClass CharacterClassName
    {
        get { return className; }
        set { className = value; }
    }

    public string ClassDescription
    {
        get { return classDescription; }
        set { classDescription = value; }
    }

    public Creature Creature
    {
        get { return creature; }
        set { creature = value; }
    }

    public int ClassLevel
    {
        get { return classLevel; }
        set { classLevel = value; }
    }
}
