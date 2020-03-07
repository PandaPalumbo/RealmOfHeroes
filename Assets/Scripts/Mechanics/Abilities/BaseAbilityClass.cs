using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbilityClass  
{
    private Creature[] targetCreatures;
    private Vector3 targetSpot;
    private string abilityName;
    public EAbilityType abilityType;
    private EAbilityAction[] abilityActions;
    private Vector2[] areaOfEffect;
    private List<AbilityBehaviors> abilityBehaviors;
    private Sprite icon;
    private GameObject particleEffect;

    public Creature[] TargetCreatures {
        get { return targetCreatures; }
        set { targetCreatures = value; }
    }
    public string AbilityName
    {
        get { return abilityName; }
        set { abilityName = value; }
    }
    public Vector3 TargetSpot
    {
        get { return targetSpot; }
        set { targetSpot = value; }
    }
    public EAbilityType AbilityType
    {
        get { return abilityType; }
        set { abilityType = value; }
    }
    public EAbilityAction[] AbilityActions
    {
        get { return abilityActions; }
        set { abilityActions = value; }
    }
    public Vector2[] AreaOfEffect
    {
        get { return areaOfEffect; }
        set { areaOfEffect = value; }
    }

    public List<AbilityBehaviors> AbilityBehaviors
    {
        get { return abilityBehaviors; }
        set { abilityBehaviors = value; }
    }

    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    public GameObject ParticleEffect
    {
        get { return particleEffect; }
        set { particleEffect = value; }
    }
}
