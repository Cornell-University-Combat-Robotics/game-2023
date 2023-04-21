using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectWidget : MonoBehaviour
{

  public enum Robot
  {
    Rosie,
    Florence
  }

  public int PlayerID = -1;

  public Robot? SelectedRobot = null;

  public Text PlayerIDLabel;
  public Text RobotNameLabel;

  void Start()
  {
    UpdateSelection();
  }

  public void UpdateSelection()
  {
    PlayerIDLabel.text = "P" + (PlayerID + 1).ToString();
    RobotNameLabel.text = SelectedRobot.ToString();
  }
}
