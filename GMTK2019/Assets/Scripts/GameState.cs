﻿using System.Collections;
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
			boardStateAI[i] = new int[9];
			boardDisplay[i] = new BoardTile[9];
			for (int j = 0; j < 9; j++)
            {
				boardState[i][j] = (int)designTileState.EMPTY;
				boardStateAI[i][j] = (int)designTileState.EMPTY;

				GameObject temp  = Instantiate(designTilePrefab, new Vector3(i - 4f, j - 4f, 0), Quaternion.identity, Board.transform);
                BoardTile temporary = temp.GetComponent(typeof(BoardTile)) as BoardTile;
				temporary.gameState = this;
				temporary.boardPos = new Vector2Int(i, j);
				boardDisplay[i][j] = temporary;
				// create a tile located at I,J

			}
        }
		generateAIBoard();

	}
	public int[][] boardStateAI = new int[9][];
	public BoardTile[][] boardDisplayAI = new BoardTile[9][];

	void generateAIBoard()
	{
		int startPosX = Random.Range(0, 8);
		int startPosY = Random.Range(0, 8);
		int x = startPosX;
		int y = startPosY;
		boardStateAI[startPosX][startPosY] = (int)designTileState.OCCUPIED;
		int AITileTotal = 1;
        while (AITileTotal < 17)
		{
			int direction = Random.Range(0, 3);
            if (direction == 1)
			{
                if (x < 8)
				{
					x += 1;
					if (boardStateAI[x][y] == (int)designTileState.OCCUPIED)
					{
						boardStateAI[x][y] = (int)designTileState.OCCUPIED;
						AITileTotal++;
					}
				}
                else
				{
					//pass;
				}
				
			}else if (direction == 2)
			{
				if (x > 0)
				{
					x -= 1;
					if (boardStateAI[x][y] == (int)designTileState.OCCUPIED)
					{
						boardStateAI[x][y] = (int)designTileState.OCCUPIED;
						AITileTotal++;
					}
				}
				else
				{
					//pass;
				}

			}
			else if (direction == 3)
			{
				if (y > 0)
				{
					y -= 1;
					if (boardStateAI[x][y] == (int)designTileState.OCCUPIED)
					{
						boardStateAI[x][y] = (int)designTileState.OCCUPIED;
						AITileTotal++;
					}
				}
				else
				{
					//pass;
				}

			}
			else if (direction == 4)
			{
				if (y < 8)
				{
					y += 1;
					if (boardStateAI[x][y] != (int)designTileState.OCCUPIED)
					{
						boardStateAI[x][y] = (int)designTileState.OCCUPIED;
						AITileTotal++;
					}
				}
				else
				{
					//pass;
				}

			}

		}
		Debug.Log("ai board initialized");
		//
	}

	public bool initPlace = false;
	int tileTotal = 0;
	enum designTileState { EMPTY, OCCUPIED };

	public bool validDesign(Vector2Int shotPos)
	{
		Debug.Log(shotPos.x + " " + shotPos.y);
		//return true;
		if (boardState[shotPos.x][shotPos.y] == (int)designTileState.OCCUPIED)
		{
			Debug.Log("occupied");
			return false;
		}
			if (initPlace)
		{
			/// check for one neighbor
			//return true;
            if (tileTotal > 17)
			{
				Debug.Log("too many");
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
			Debug.Log("no valid neighbors");
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
		initPlace = false;
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
