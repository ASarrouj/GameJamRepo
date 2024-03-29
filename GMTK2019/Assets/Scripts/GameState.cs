﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    //ArrayList<ArrayList<int>> boardState;
    public int[][] boardState = new int[9][];
    private int waitTime = 0;
    public BoardTile [][] boardDisplay = new BoardTile[9][];
	public Battleship player;
	public Battleship AI;
	public GameObject designTilePrefab;
	public GameObject Board;
    public Button submitButton, clearButton;
    public GameObject camera;
    public GameObject tilesLeftText, resultText, designText, instructionsText, yourBoardText, turnText;
    private TextMesh tilesLeftMesh, resultTextMesh, turnTextMesh;
    private CameraManager camManager;
    public bool isPlayerTurn;

   // ArrayList 
    // Start is called before the first frame update
    void Start()
    {
        camManager = camera.GetComponent<CameraManager>();
        tilesLeftMesh = tilesLeftText.GetComponent<TextMesh>();
        resultTextMesh = resultText.GetComponent<TextMesh>();
        turnTextMesh = resultText.GetComponent<TextMesh>();
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

				temporary.isPlayer = true;
	            boardDisplay[i][j] = temporary;
				// create a tile located at I,J

			}
        }
		

	}
	public int[][] boardStateAI = new int[9][];
	public BoardTile[][] boardDisplayAI = new BoardTile[9][];

	void generateAIBoard()
	{
		int startPosX = Random.Range(0, 8);
		int startPosY = Random.Range(0, 8);
		Debug.Log(startPosX + " " + startPosY);
		int x = startPosX;
		int y = startPosY;
		boardStateAI[startPosX][startPosY] = (int)designTileState.OCCUPIED;
		int AITileTotal = 1;
        while (AITileTotal < 16)
		{
			int direction = Random.Range(0, 4);
            if (direction == 1)
			{
                if (x < 8)
				{
					x += 1;
					if (boardStateAI[x][y] == (int)designTileState.EMPTY)
					{
						Debug.Log("generating at"+  x + " " + y + " " + AITileTotal);
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
					if (boardStateAI[x][y] == (int)designTileState.EMPTY)
					{
						Debug.Log("generating at" + x + " " + y + " " + AITileTotal);
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
					if (boardStateAI[x][y] == (int)designTileState.EMPTY)
					{
						Debug.Log("generating at" +  x + " " + y + " " + AITileTotal);
						boardStateAI[x][y] = (int)designTileState.OCCUPIED;
						AITileTotal++;
					}
				}
				else
				{
					//pass;
				}

			}
			else if (direction == 0)
			{
				if (y < 8)
				{
					y += 1;
					if (boardStateAI[x][y] == (int)designTileState.EMPTY)
					{
						Debug.Log("generating at" +  x + " " + y + " " + AITileTotal);
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
            if (tileTotal > 16)
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

	public void submit()
	{
		Debug.Log("pressed submit");
		Debug.Log(tileTotal); ;
		if (tileTotal == 17)
		{
			/// do thing
			Debug.Log("submitted");
			generateAIBoard();

            submitButton.gameObject.SetActive(false);
            clearButton.gameObject.SetActive(false);
            instructionsText.SetActive(false);
            designText.SetActive(false);
            tilesLeftText.SetActive(false);
            //yourBoardText.SetActive(true);
            turnText.SetActive(true);
            camManager.BeginInterpolation();

            isPlayerTurn = true;
            currentPhase = (int)phase.BATTLE;
		}
	}

	public bool validErase(Vector2Int shotPos)
	{
    //// not implemented due to time, 

		tileTotal--;
		return true;  
	}

    public void initializeBattleScreen()
	{

		player = new Battleship(boardState);
		AI = new Battleship(boardStateAI);
		initBattle = true;
		for (int i = 0; i < 9; i++)
		{
			//boardState[i] = new int[9];
			//boardStateAI[i] = new int[9];
		    boardDisplayAI[i] = new BoardTile[9];
			for (int j = 0; j < 9; j++)
			{
				//boardState[i][j] = (int)designTileState.EMPTY;
				//boardStateAI[i][j] = (int)designTileState.EMPTY;

				GameObject temp = Instantiate(designTilePrefab, new Vector3(i - 4f  + 16f, j - 4f, 0), Quaternion.identity, Board.transform);
				BoardTile temporary = temp.GetComponent(typeof(BoardTile)) as BoardTile;
				temporary.gameState = this;
				temporary.boardPos = new Vector2Int(i, j);
				temporary.isPlayer = false;
				boardDisplayAI[i][j] = temporary;
				// create a tile located at I,J

			}
		}
		//return 0 ;
	}
	private bool initBattle = false;

    public enum phase { TITLE, DESIGN, BATTLE, END}

    public int getGamePhase()
	{
		Debug.Log(currentPhase);
		return currentPhase;
	}


    public bool isHit(Vector2Int shotPos)
	{

		Debug.Log(shotPos.x + " " + shotPos.y);
		///return true;
		bool shotResult = AI.CheckIfShotHit(shotPos);
		//Debug.Log(shotResult);

        if (shotResult == true)
		{

			boardDisplayAI[shotPos.x][shotPos.y].DisplayHit();
            
			bool win1 = AI.IsBattleshipDestroyed();
			//AI check if win
			if (win1)
			{
				Debug.Log("player wins");
				//currentPhase = (int)phase.TITLE;
			}

			return true;

		}


		boardDisplayAI[shotPos.x][shotPos.y].DisplayMiss();

		bool win = AI.IsBattleshipDestroyed();
		//AI check if win
		if (win)
		{
			Debug.Log("player wins");
			//currentPhase = (int)phase.TITLE;
		}
		return false;

	}

	private Dictionary<Vector2Int, int> shots = new Dictionary<Vector2Int, int>();


    public bool AIMove()
	{
		
		Vector2Int shotPos = new Vector2Int(Random.Range(0, 9), Random.Range(0, 9));
        while (shots.ContainsKey(shotPos))
		{
			shotPos = new Vector2Int(Random.Range(0, 9), Random.Range(0, 9));
		}
		shots[shotPos] = 1;


			

		if (player.CheckIfShotHit(shotPos))
		{
			boardDisplay[shotPos.x][shotPos.y].DisplayHit();

			bool win2 = player.IsBattleshipDestroyed();
			//AI check if win
			if (win2)
			{
				Debug.Log("AI wins");
				//currentPhase = (int)phase.TITLE;
			}

			return true;
		}
		else
		{
			boardDisplay[shotPos.x][shotPos.y].DisplayMiss();
		}

		bool win = player.IsBattleshipDestroyed();
		//AI check if win
		if (win)
		{
			Debug.Log("AI wins");
            
			///quit();
			//currentPhase = (int)phase.TITLE;
		}
		return true;
	}



    private int currentPhase = (int) phase.DESIGN;

    // Update is called once per frame
    void Update()
    {
		
		if (currentPhase == (int)phase.TITLE)
        {/// show a title screen

		}
		else if (currentPhase == (int)phase.DESIGN)
        {
            tilesLeftMesh.text = "Tiles\nLeft: " + (17 - tileTotal);
		}
		else if (currentPhase == (int)phase.BATTLE)
        {
            /// battle
			if (initBattle == false)
			{
				initializeBattleScreen();
			}
            if (AI.IsBattleshipDestroyed())
			{
                resultText.SetActive(true);
                resultTextMesh.text = "Player\nWins!";
				currentPhase = (int)phase.END;
			}
			if (player.IsBattleshipDestroyed())
			{
                resultText.SetActive(true);
                resultTextMesh.text = "AI\nWins!";
                currentPhase = (int)phase.END;
			}


			if (!isPlayerTurn)
            {
                AIMove();
                isPlayerTurn = true;
            }

        }
        else if (currentPhase == (int)phase.END)
        {
            waitTime += 1;
            if (waitTime >= 300)
            {
                SceneManager.LoadScene("TitleScreen");
            }
        }

        
        


    }
}
