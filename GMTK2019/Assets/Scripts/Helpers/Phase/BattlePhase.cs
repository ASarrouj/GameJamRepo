using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePhase : IPhase
{
    private GameState gameState;

    public BattlePhase(GameState gameState)
    {
        this.gameState = gameState;
    }

    public void HandleTileClick(Vector2Int boardPos)
    {

    }
}
