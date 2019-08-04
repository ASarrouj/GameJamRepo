using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battleship
{
    private BattleshipTile[] battleshipTiles;
    public int unhitTilesLeft;

    public Battleship()
    {
        battleshipTiles = new BattleshipTile[17];
        unhitTilesLeft = 17;
    }

    public bool CheckIfShotHit(Vector2Int shotPos)
    {
        foreach (BattleshipTile tile in battleshipTiles)
        {
            if (tile.isHit(shotPos))
            {
                unhitTilesLeft--;
                return true;
            }
        }
        return false;
    }
}
