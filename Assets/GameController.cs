using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;
    public GameObject gameOverPanel;
    public Text gameOverText;
    private int moveCount;
    public GameObject restarButton;
    void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerReferrenceOnButtons();
        playerSide = "X";
        moveCount = 0;
        restarButton.SetActive(false);
    }
    void SetGameControllerReferrenceOnButtons()
    {
        for (int i= 0;i < buttonList.Length; i++){
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);


        }
    }
    public string GetPlayerSide()
    {
        return playerSide;

    }
    public void EndTurn()
    {
        moveCount++;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);        }
        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        if (moveCount >= 9)
        {
            GameOver("draw");
       
        }
        ChangeSides();
    }
    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);

        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a Draw!");
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }
        restarButton.SetActive(true);
    }
    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }
    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        SetBoardInteractable(true);
        for (int i = 0; i < buttonList.Length; i++)
        {
            
            buttonList[i].text = "";

        }
        restarButton.SetActive(false);
    }
    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;

        }
    }



}
