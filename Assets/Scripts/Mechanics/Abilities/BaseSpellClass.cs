using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpellClass : BaseAbilityClass
{

    public BaseSpellClass(string name, Creature[] targetCreatures, Vector2 targetSpot, EAbilityAction[] abilityActions, Vector2[] areaOfEffect,  Sprite icon, GameObject particleEffect)
    {
        AbilityType = EAbilityType.Spell;
        TargetCreatures = targetCreatures;
        AbilityName = name;
        TargetSpot = targetSpot;
        AbilityActions = abilityActions;
        Icon = icon;
        ParticleEffect = particleEffect;
        AreaOfEffect = areaOfEffect;
    }
}
