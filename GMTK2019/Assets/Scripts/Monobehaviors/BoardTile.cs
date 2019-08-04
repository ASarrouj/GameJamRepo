using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    public GameState gameState;
    private SpriteRenderer tileSprite, xSprite, powSprite;
    public Vector2Int boardPos;
    private bool selected;
    private Color defaultColor;
    public bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        tileSprite = transform.Find("TileSquare").GetComponent<SpriteRenderer>();
        xSprite = transform.Find("MissX").GetComponent<SpriteRenderer>();
        powSprite = transform.Find("HitEffect").GetComponent<SpriteRenderer>();
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

    public void Deselect()
    {
        tileSprite.color = defaultColor;
        selected = false;
    }

    public void DisplayMiss()
    {
        xSprite.gameObject.SetActive(true);
    }

    public void DisplayHit()
    {
        powSprite.gameObject.SetActive(true);
    }

    private void OnMouseDown()
    {
        Debug.Log(boardPos.x + " " + boardPos.y);
        Debug.Log(gameState.getGamePhase());
        if (gameState.getGamePhase() == (int)phase.DESIGN)
        {
            if (!selected)
            {
                if (gameState.validDesign(boardPos))
                {
                    tileSprite.color = Color.gray;
                    selected = true;
                }
            }
            /*
            else
            {
                if (true) //Logic for unselecting goes here
                {
                    Deselect();
                }
            }*/
        }else if (gameState.getGamePhase() == (int)phase.BATTLE)
        {
            gameState.isHit(boardPos);
        }
    }

    public enum phase { TITLE, DESIGN, BATTLE }
}
