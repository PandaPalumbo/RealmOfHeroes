using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestroyable {
    float maxHp { get; set; }
    float currentHp { get; set; }

    void DestroyOnScreen();
}
