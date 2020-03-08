using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable{
    float maxHp { get; set; }
    float currentHp { get; set; }
    void TakeDamage<T>(T damageTaken);
}
