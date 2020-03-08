using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit :  IDamagable
{
    public float maxHp { get; set; }
    public float currentHp { get ; set ; }

    public void TakeDamage<T>(T damageTaken)
    {
        throw new System.NotImplementedException();
    }

}
