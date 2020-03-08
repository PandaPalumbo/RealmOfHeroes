using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameState { OUT_OF_COMBAT, IN_COMBAT }
public class GameState : MonoBehaviour
{
    
    public CombatMechanics combatMechanicsHandler;
    public OutOfCombatMechanics outOfCombatMechanicsHandler;
    public EGameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = EGameState.IN_COMBAT;
    }

   
}
