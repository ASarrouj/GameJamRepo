using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //ArrayList<ArrayList<int>> boardState;
    public int[][] boardState = new int[9][];
    public BoardTile [][] boardDisplay = new BoardTile[9][];
	public GameObject designTilePrefab;
	public GameObject Board;
   // ArrayList 
    // Start is called before the first frame update
    void Start()
    {
		//boardState[i] = new int[9];
        for (int i =0; i < 9; i++)
        {
			boardState[i] = new int[9];
			boardDisplay[i] = new BoardTile[9];
			for (int j = 0; j < 9; j++)
            {
				boardState[i][j] = (int)designTileState.EMPTY;

				GameObject temp  = Instantiate(designTilePrefab, new Vector3(i, j, 0), Quaternion.identity, Board.transform);
                BoardTile temporary = temp.GetComponent(typeof(BoardTile)) as BoardTile;
				temporary.gameState = this;
				temporary.boardPos = new Vector2Int(i, j);
				boardDisplay[i][j] = temporary;
				// create a tile located at I,J

			}
        }
    }

	public bool initPlace = false;
	int tileTotal = 0;
	enum designTileState { EMPTY, OCCUPIED };

	public bool validDesign(Vector2Int shotPos)
	{
		Debug.Log(shotPos.x + " " + shotPos.y);
		//return true;
		if (initPlace)
		{
			/// check for one neighbor
			//return true;
            if (tileTotal > 17)
			{
				return false;
			}
            if (shotPos.x < 8)
				if ( boardState[shotPos.x + 1][shotPos.y] == (int) designTileState.OCCUPIED)
				{
					boardState[shotPos.x][shotPos.y] = (int) designTileState.OCCUPIED;
					tileTotal++;
					return true;
				}
			if (shotPos.x > 0)
				if (boardState[shotPos.x - 1][shotPos.y] ==  (int) designTileState.OCCUPIED )
				{
					boardState[shotPos.x][shotPos.y] = (int)designTileState.OCCUPIED;
					tileTotal++;
					return true;
				}
			if(shotPos.y > 0)
				if (boardState[shotPos.x][shotPos.y -1] == (int)designTileState.OCCUPIED)
			    {
					boardState[shotPos.x][shotPos.y] = (int)designTileState.OCCUPIED;
					tileTotal++;
					return true;
			    }
			if (shotPos.y < 8)
				if (boardState[shotPos.x][shotPos.y + 1] == (int)designTileState.OCCUPIED)
				{
					boardState[shotPos.x][shotPos.y] = (int)designTileState.OCCUPIED;
					tileTotal++;
					return true;
				}

			return false;

		}
		else
		{
			boardState[shotPos.x][shotPos.y] = (int)designTileState.OCCUPIED;
			initPlace = true;
			tileTotal++;
			return true;
		}
	}


	public void clear()
	{
		
		tileTotal=0;
		for (int i = 0; i < 9; i++)
		{
            for (int j = 0; j < 9; j++)
			{
				boardState[i][j] = (int)designTileState.EMPTY;
				boardDisplay[i][j].Deselect();
			}
		}
	}

	public bool validErase(Vector2Int shotPos)
	{
    //// not implemented due to time, 

		tileTotal--;
		return true;  
	}
    enum phase { TITLE, DESIGN, BATTLE}

    private int currentPhase = (int) phase.TITLE;

    // Update is called once per frame
    void Update()
    {

        if (currentPhase == (int)phase.TITLE)
        {

        }
        else if (currentPhase == (int)phase.DESIGN)
        {

        }
        else if (currentPhase == (int)phase.BATTLE)
        {

        }

        /// show a title screen
        ///

        /// design a ship
        ///

        /// first create a board
        ///

        /// design phase
        ///
        //if 


    }
}
