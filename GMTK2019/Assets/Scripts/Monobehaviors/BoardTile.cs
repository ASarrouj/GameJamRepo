using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    public GameState gameState;
    private SpriteRenderer tileSprite;
    public Vector2Int boardPos;
    private bool selected;
    private Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        tileSprite = transform.Find("TileSquare").GetComponent<SpriteRenderer>();
        defaultColor = new Color(tileSprite.color.r, tileSprite.color.g, tileSprite.color.b);
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBoardPos(Vector2Int boardPos)
    {
        this.boardPos = boardPos;
    }

    private void OnMouseDown()
    {
        if (!selected)
        {
            if (gameState.validDesign(boardPos))
            {
                tileSprite.color = Color.gray;
                selected = true;
            }
        }
        else
        {
            if (true) //Logic for unselecting goes here
            {
                tileSprite.color = defaultColor;
                selected = false;
            }
        }
    }
}
