using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Ability", menuName = "Ability")]
public class Ability : ScriptableObject
{
    public List<Creature> targetCreatures;
    public Vector3 targetSpot;
    public string abilityName;
    public EAbilityType abilityType;
    public List<EAbilityAction> abilityActions;
    public List<Vector3> areaOfEffect;
    public Sprite icon;
    public GameObject particleEffect;
    public string description;
    public int damage;
    public int heal;
    public int buff;
    public int debuff;
    public List<ECreatureAttributes> creatureAttributes;
    public EDamageType damageType;
    public int spellLvl;
    public Item item;

}
