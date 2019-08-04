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
        Debug.Log("this tile is At" + tilePos.x + " " + tilePos.y);
        Debug.Log("this shot is At" + shotPos.x + " " + shotPos.y);
        if (shotPos == tilePos)
        {
            hitStatus = true;
        }
        else
        {
            hitStatus = false;
        }
        Debug.Log("returning" + hitStatus);
        return hitStatus;
    }
}
