using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleshipTile
{

    Vector2Int tilePos;
    bool hitStatus = false;

    public BattleshipTile(Vector2Int tilePos)
    {
        this.tilePos = tilePos;
    }

    public bool isHit(Vector2Int shotPos)
    {
        if (shotPos == tilePos)
        {
            hitStatus = true;
        }
        return hitStatus;
    }
}
