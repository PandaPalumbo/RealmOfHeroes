using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICreature
{
    //info
    string name { get; set; }
    string title { get; set; }
    string description { get; set; }
    ECreatureTypes creatureType { get; set; }
    EHumanoidRaces humanoidRace { get; set; }

    //attributes
    int level { get; set; }
    int actionPoints { get; set; }
    int gameSpeed { get; set; }   
    int originalAP { get; set; }
    int strength { get; set; }
    int dexterity{ get; set; }
    int constitution { get; set; }
    int intelligence { get; set; }
    int wisdom { get; set; }
    int charisma { get; set; }

    void Attack();

}
