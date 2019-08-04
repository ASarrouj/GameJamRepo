using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battleship
{
    private List<BattleshipTile> battleshipTiles;
    public int unhitTilesLeft;

    public Battleship(int[][] boardState)
    {
        Debug.Log("creating  a battleship");
        battleshipTiles = new List<BattleshipTile>();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (boardState[i][j] == 1)
                {
                    //Debug.Log("creating tile at" + i + " "+j);
                    battleshipTiles.Add(new BattleshipTile(new Vector2Int(i, j)));
                    //Debug.Log("there are now " + battleshipTiles.Count + "tiles placed");
                }
            }
        }
        unhitTilesLeft = 17;
    }

    public bool CheckIfShotHit(Vector2Int shotPos)
    {
        foreach (BattleshipTile tile in battleshipTiles)
        {
            Debug.Log(battleshipTiles.Count);
            Debug.Log("checking tile..");
            if (tile.isHit(shotPos))
            {
                unhitTilesLeft--;
                return true;
            }
        }
        return false;
    }

    public bool IsBattleshipDestroyed()
    {
        if (unhitTilesLeft <= 0)
        {
            return true;
        }
        return false;
    }
}
