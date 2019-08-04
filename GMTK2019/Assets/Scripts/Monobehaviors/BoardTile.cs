using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    public GameState gameState;
    private Transform tileSprite;
    private Vector2 boardPos;

    // Start is called before the first frame update
    void Start()
    {
        tileSprite = transform.Find("TileSquare");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBoardPos(Vector2 boardPos)
    {
        this.boardPos = boardPos;
    }

    private void OnMouseDown()
    {
        if (gameState.validDesign(boardPos))
        {
            tileSprite.GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }
}
