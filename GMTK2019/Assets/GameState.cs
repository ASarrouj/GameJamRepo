using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    //ArrayList<ArrayList<int>> boardState;
    public int[][] boardState = new int[9];



    ArrayList 
    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i < 9; i++)
        {
            for (int j = 0; i < 9; i++)
            {
                 // create a tile located at I,J

            }
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
