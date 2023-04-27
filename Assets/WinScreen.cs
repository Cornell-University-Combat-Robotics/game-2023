using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Text WinningPlayer;
    public Text WinningRobot;
    public Image PlayerColorPanel;
    
    public void UpdateWinner(int playerID)
    {
        var config = GameManager.Instance.PlayerData[playerID];
        WinningPlayer.text = "P" + (playerID + 1).ToString();
        WinningRobot.text = config.robot.ToString();
        PlayerColorPanel.color = GameManager.PlayerColors[playerID];
    } 
}
