using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbilityClass  
{
    private Creature[] targetCreatures;
    private Vector3 targetSpot;
    private string abilityName;
    private EAbilityType abilityType;
    private EAbilityAction[] abilityActions;

    public Creature[] TargetCreatures { get => targetCreatures; set => targetCreatures = value; }
    public string AbilityName { get => abilityName; set => abilityName = value; }
    public Vector3 TargetSpot { get => targetSpot; set => targetSpot = value; }
    public EAbilityType AbilityType { get => abilityType; set => abilityType = value; }
    public EAbilityAction[] AbilityActions { get => abilityActions; set => abilityActions = value; }
}
