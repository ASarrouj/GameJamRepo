using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleshipTile
{

    Vector2 tilePos;
    bool hitStatus = false;

    public BattleshipTile(Vector2 tilePos)
    {
        this.tilePos = tilePos;
    }

    public bool isHit(Vector2 shotPos)
    {
        if (shotPos == tilePos)
        {
            hitStatus = true;
        }
        return hitStatus;
    }
}
