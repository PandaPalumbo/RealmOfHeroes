using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    public Ability ability;
    public Hero caster;
    public List<Creature> targetCreatures;
    private Vector3 targetSpot;
    private string abilityName;
    private EAbilityType abilityType;
    private List<EAbilityAction> abilityActions;
    private List<Vector3> areaOfEffect;
    private Sprite icon;
    private GameObject particleEffect;
    private string description;
    private int damage;
    private int heal;
    private int buff;
    private int debuff;
    private List<ECreatureAttributes> creatureAttributes;
    private EDamageType damageType;
    public Item item;

    // Start is called before the first frame update
    void Start()
    {
        targetSpot = ability.targetSpot;
        abilityName = ability.abilityName;
        abilityType = ability.abilityType;
        abilityActions = ability.abilityActions;
        areaOfEffect = ability.areaOfEffect;
        icon = ability.icon;
        particleEffect = ability.particleEffect;
        description = ability.description;
        damage = ability.damage;
        heal = ability.heal;
        buff = ability.buff;
        debuff = ability.debuff;
        creatureAttributes = ability.creatureAttributes;
        targetCreatures = ability.targetCreatures;
        damageType = ability.damageType;
    }

    public void UseAbility(Creature user)
    {
        if(abilityType == EAbilityType.Spell)
        {
            CastSpell(caster);
        }
        if (abilityType == EAbilityType.Equipment)
        {
            UseEquipmentAbility(user);
        }
    }

    public void UseEquipmentAbility(Creature user)
    {
        if (abilityActions.Contains(EAbilityAction.Attack))
        {
            foreach (Creature creature in targetCreatures)
            {
                if(item != null)
                {
             
                }
             
            }
        }
        if (abilityActions.Contains(EAbilityAction.Heal))
        {
            foreach (Creature creature in targetCreatures)
            {
                creature.TakeHeal(heal);
            }
        }
        if (abilityActions.Contains(EAbilityAction.Buff))
        {
            foreach (Creature creature in targetCreatures)
            {
                foreach (ECreatureAttributes attribute in creatureAttributes)
                {
                    creature.TakeBuff(buff, attribute);
                }
            }
        }
        if (abilityActions.Contains(EAbilityAction.Debuff))
        {
            foreach (Creature creature in targetCreatures)
            {
                foreach (ECreatureAttributes attribute in creatureAttributes)
                {
                    creature.TakeDebuff(debuff, attribute);
                }
            }
        }
        
    }

    //TODO add variable targeting (can hit enemies? can hit friendlies? can hit all?)
    public void CastSpell(Hero caster)
    {
        if(caster.spellSlots[ability.spellLvl - 1] != 0)
        {
            
            caster.spellSlots[ability.spellLvl- 1] -= 1;
            Debug.Log("" + caster.spellSlots[ability.spellLvl - 1] + " slots of " + ability.spellLvl + " level spells");
            if (abilityActions.Contains(EAbilityAction.Attack))
            {
                foreach (Creature creature in targetCreatures)
                {
                    creature.TakeDamage(damage, damageType);
                }
            }
            if (abilityActions.Contains(EAbilityAction.Heal))
            {
                foreach (Creature creature in targetCreatures)
                {
                    creature.TakeHeal(heal);
                }
            }
            if (abilityActions.Contains(EAbilityAction.Buff))
            {
                foreach (Creature creature in targetCreatures)
                {
                    foreach (ECreatureAttributes attribute in creatureAttributes)
                    {
                        creature.TakeBuff(buff, attribute);
                    }
                }
            }
            if (abilityActions.Contains(EAbilityAction.Debuff))
            {
                foreach (Creature creature in targetCreatures)
                {
                    foreach (ECreatureAttributes attribute in creatureAttributes)
                    {
                        creature.TakeDebuff(debuff, attribute);
                    }
                }
            }
        }
        else
        {
            Debug.Log("No more spell slots!");
            //TODO no spell slots
        }
    }
}
