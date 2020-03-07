using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfCombatMechanics : MonoBehaviour
{
    public GameState gameState;
    public bool OutOfCombat;
    public int playerControllerId;
    public playerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetGameState();
        if(OutOfCombat == true)
        {
            if (Verify())
            {
                playerController.canIMove = true;
            }
        }
    }


    private void GetGameState()
    {
        if (gameState.gameState == EGameState.OUT_OF_COMBAT)
        {
            OutOfCombat = true;
        }
        else
        {
            OutOfCombat = false;
        }
    }

    private bool Verify()
    {
        if(playerControllerId == playerController.id)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
