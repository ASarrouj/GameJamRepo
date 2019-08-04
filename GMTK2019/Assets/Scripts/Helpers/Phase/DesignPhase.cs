using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignPhase : IPhase
{

    private GameState gameState;

    public DesignPhase(GameState gameState)
    {
        this.gameState = gameState;
    }

    public void HandleTileClick(Vector2Int boardPos)
    {

    }
}
