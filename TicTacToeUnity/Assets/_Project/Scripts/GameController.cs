using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Text finishText;
    [SerializeField]
    TokensController tokensController;

    [HideInInspector]
    public bool CanInteractWithGame;

    List<Tile> tiles;
    List<Tile> availableTiles;

    bool gameEnd = false;

    private void Awake()
    { 
        tiles = new List<Tile>();
        Tile[] allTiles = transform.GetComponentsInChildren<Tile>();
        for (int i = 0; i < allTiles.Length; i++)
        {
            allTiles[i].MyIndex = i;
            tiles.Add(allTiles[i]);
        }

        finishText.gameObject.SetActive(false);
        availableTiles = new List<Tile>(tiles);
        CanInteractWithGame = true;
    }

    public void OnTileClick(int tileIndex)
    {
        for (int i = 0; i < availableTiles.Count; i++)
        {
            if (availableTiles[i].MyIndex == tileIndex)
            {
                availableTiles.RemoveAt(i);
                break;
            }
        }
        CheckForWin();
        StartCoroutine(AIPlay());
    }

    private IEnumerator AIPlay()
    {
        CanInteractWithGame = false;
        yield return new WaitForSeconds(0.5f);

        if (availableTiles.Count > 1 && !gameEnd)
        {
            int sortingNumber = Random.Range(0, availableTiles.Count);
            availableTiles[sortingNumber].FillTile(false);
            availableTiles.RemoveAt(sortingNumber);
            CanInteractWithGame = true;
            CheckForWin();
        }
    }

    private void CheckForWin()
    {
        if (CheckXSpace())        
            FinishGame(GameResult.VICTORY);        
        else if (CheckOSpace())        
            FinishGame(GameResult.DEFEAT);        
        else if (availableTiles.Count <= 0)        
            FinishGame(GameResult.TIE);            
    }

    bool CheckXSpace()
    {
        return 
            //First Row 
            tiles[0].IsFilledX && tiles[1].IsFilledX && tiles[2].IsFilledX ||
            // Second Row
            tiles[3].IsFilledX && tiles[4].IsFilledX && tiles[5].IsFilledX ||
            // Third Row
            tiles[6].IsFilledX && tiles[7].IsFilledX && tiles[8].IsFilledX ||
            //First Column 
            tiles[0].IsFilledX && tiles[3].IsFilledX && tiles[6].IsFilledX ||
            //Second Column 
            tiles[1].IsFilledX && tiles[4].IsFilledX && tiles[7].IsFilledX ||
            //Third Column 
            tiles[2].IsFilledX && tiles[5].IsFilledX && tiles[8].IsFilledX ||
            //First Diagonal 
            tiles[0].IsFilledX && tiles[4].IsFilledX && tiles[8].IsFilledX ||
            //Second Diagonal 
            tiles[2].IsFilledX && tiles[4].IsFilledX && tiles[6].IsFilledX;
    }

    bool CheckOSpace()
    {
        return
            //First Row 
            tiles[0].IsFilledX && tiles[1].IsFilledX && tiles[2].IsFilledX ||
            // Second Row
            tiles[3].IsFilledX && tiles[4].IsFilledX && tiles[5].IsFilledX ||
            // Third Row
            tiles[6].IsFilledX && tiles[7].IsFilledX && tiles[8].IsFilledX ||
            //First Column 
            tiles[0].IsFilledX && tiles[3].IsFilledX && tiles[6].IsFilledX ||
            //Second Column 
            tiles[1].IsFilledX && tiles[4].IsFilledX && tiles[7].IsFilledX ||
            //Third Column 
            tiles[2].IsFilledX && tiles[5].IsFilledX && tiles[8].IsFilledX ||
            //First Diagonal 
            tiles[0].IsFilledX && tiles[4].IsFilledX && tiles[8].IsFilledX ||
            //Second Diagonal 
            tiles[2].IsFilledX && tiles[4].IsFilledX && tiles[6].IsFilledX;
    }

    void FinishGame(GameResult result)
    {
        CanInteractWithGame = false;
        gameEnd = true;
        finishText.gameObject.SetActive(true);

        switch (result)
        {
            case GameResult.VICTORY:
                finishText.color = Color.green;
                finishText.text = "Win!";
                tokensController.AddCoin(1);
                break;
            case GameResult.TIE:
                finishText.color = Color.yellow;
                finishText.text = "Tie!";
                break;
            case GameResult.DEFEAT:
                finishText.color = Color.red;
                finishText.text = "Lose!";
                break;
        }

        Invoke("ResetGame", 2.0f);
    }

    private void ResetGame()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].ResetTile();
        }
        availableTiles = new List<Tile>(tiles);
        CanInteractWithGame = true;
        gameEnd = false;
        finishText.gameObject.SetActive(false);
    }
}
