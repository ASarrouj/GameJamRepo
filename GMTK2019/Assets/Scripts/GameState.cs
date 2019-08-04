using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //ArrayList<ArrayList<int>> boardState;
    public int[][] boardState;// = new int[9];



   // ArrayList 
    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
				boardState[i][j] = (int)designTileState.EMPTY;

                 // create a tile located at I,J

            }
        }
    }

	public bool initPlace = false;
	int tileTotal = 0;
	enum designTileState { EMPTY, OCCUPIED };

	public bool validDesign(Vector2Int shotPos)
	{

        if (initPlace)
		{
			/// check for one neighbor

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
				if (boardState[shotPos.x][shotPos.y + 8] == (int)designTileState.OCCUPIED)
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
