using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhase
{
    void HandleTileClick(Vector2Int boardPos);
}
