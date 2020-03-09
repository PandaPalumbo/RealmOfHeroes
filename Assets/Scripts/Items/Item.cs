using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public Sprite icon;
    public string itemName;
    public string description;
    public int goldValue;
    public int weight;

    public int naturalDamage;
    public bool isCraftable;
    public List<Item> components;
    public List<Ability> abiliities;
    public List<int> attrIncreases;
    public List<int> attrDecreases;
    public List<ECreatureAttributes> eAttrIncreases;
    public List<ECreatureAttributes> eAttrDecreases;
    public List<EDamageType> vulnerabilities;
    public List<EDamageType> immunities;
    public List<EDamageType> resistances;
    public EDamageType additionalDamageType;
    public EItemRarity itemRarity;
}
