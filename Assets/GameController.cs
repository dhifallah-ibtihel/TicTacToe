using System.Collections;
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
    private string computerSide;
    public GameObject gameOverPanel;
    public Text gameOverText;
    private int moveCount;
    public GameObject restartButton;
    public Player PlayerX;
    public Player PlayerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
    public bool playerMove;
    public float delay;
    private int value;
    public GameObject startInfo;
   
 
    void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerReferrenceOnButtons();
     
        moveCount = 0;
        restartButton.SetActive(false);
        playerMove = true;
    
        
    }
    void Update()
    {
        if (playerMove == false)
        {
            delay += delay * Time.deltaTime;
            if (delay >= 100)
            {
                value = Random.Range(0, 8);
                if(buttonList[value].GetComponentInParent<Button>().interactable == true)
                {
                    buttonList[value].text = GetComputerSide();
                    buttonList[value].GetComponentInParent<Button>().interactable = false;
                    EndTurn();

                }
            }
        }
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
        {   computerSide = "O";
            SetPlayerColors(PlayerX, PlayerO);
        }
        else
        {
            computerSide= "X";
            SetPlayerColors(PlayerO, PlayerX);
        }
        StartGame();
    }
    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }
    public string GetPlayerSide()
    {
        return playerSide;

    }
    public string GetComputerSide()
    {
        return computerSide;

    }

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
        else if (buttonList[0].text == computerSide && buttonList[1].text == computerSide && buttonList[2].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[3].text == computerSide && buttonList[4].text == computerSide && buttonList[5].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[6].text == computerSide && buttonList[7].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[0].text == computerSide && buttonList[3].text == computerSide && buttonList[6].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[1].text == computerSide && buttonList[4].text == computerSide && buttonList[7].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[2].text == computerSide && buttonList[5].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[0].text == computerSide && buttonList[4].text == computerSide && buttonList[8].text == computerSide)
        {
            GameOver(computerSide);
        }
        else if (buttonList[2].text == computerSide && buttonList[4].text == computerSide && buttonList[6].text == computerSide)
        {
            GameOver(computerSide);
        }




        else if (moveCount >= 9)
        {
            GameOver("draw");
       
        }
        else
        {
            ChangeSides();
            delay = 10;
           
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
        //playerSide = (playerSide == "X") ? "O" : "X";
        playerMove = (playerMove == true) ? false : true;
      
       //if (playerSide == "X")
       if(playerMove == true)
    
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
        restartButton.SetActive(false);
        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        startInfo.SetActive(true);
        playerMove = true;
        delay = 10;

    

        for (int i = 0; i < buttonList.Length; i++)
        {
            
            buttonList[i].text = "";

        }
      
        
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