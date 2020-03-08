using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Spell", menuName = "Card")]
public class Spell : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;
    public int spellSlotCost;
    public int attack;
    public int heal;
    public int debuff;
    public int buff;

}
