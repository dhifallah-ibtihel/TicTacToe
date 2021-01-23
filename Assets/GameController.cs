﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;
}
[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}


public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;
    public GameObject gameOverPanel;
    public Text gameOverText;
    private int moveCount;
    public GameObject restartButton;
    public Player PlayerX;
    public Player PlayerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
   
 
    void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerReferrenceOnButtons();
     
        moveCount = 0;
        restartButton.SetActive(false);
    
        
    }
  
    void SetGameControllerReferrenceOnButtons()
    {
        for (int i= 0;i < buttonList.Length; i++){
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);


        }
    }
    public void SetStartingSide( string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
          //  computerSide = "O";
            SetPlayerColors(PlayerX, PlayerO);
        }
        else
        {
          //  computerSide = "X";
            SetPlayerColors(PlayerO, PlayerX);
        }
        StartGame();
    }
    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
    }
    public string GetPlayerSide()
    {
        return playerSide;

    }
    //public string GetComputerSide()
   // {
      //  return computerSide;

    //}
    public void EndTurn()
    {
        moveCount++;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }


  
       
        else if (moveCount >= 9)
        {
            GameOver("draw");
       
        }
        else
        {
            ChangeSides();
           
        }
       
    }
   
    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);

        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a Draw!");
            SetPlayerColorsInactive();
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }
        restartButton.SetActive(true);
    }
    void ChangeSides()
    {
         playerSide = (playerSide == "X") ? "O" : "X";
      
       if (playerSide == "X")
    
        {
            SetPlayerColors(PlayerX, PlayerO);
        }
        else
        {
            SetPlayerColors(PlayerO, PlayerX);
        }
    }
    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }
    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        
        moveCount = 0;
        gameOverPanel.SetActive(false);
      //  restartButton.SetActive(false);

        SetPlayerButtons(true);
        SetPlayerColorsInactive();
    

        for (int i = 0; i < buttonList.Length; i++)
        {
            
            buttonList[i].text = "";

        }
      
        restartButton.SetActive(false);
    }
    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;

        }
    }
    void SetPlayerButtons(bool toggle)
    {
        PlayerX.button.interactable = toggle;
        PlayerO.button.interactable = toggle;
    }
    void SetPlayerColorsInactive()
    {
        PlayerX.panel.color = inactivePlayerColor.panelColor;
        PlayerX.text.color = inactivePlayerColor.textColor;
        PlayerO.panel.color = inactivePlayerColor.panelColor;
        PlayerO.text.color = inactivePlayerColor.textColor;
    }



}
