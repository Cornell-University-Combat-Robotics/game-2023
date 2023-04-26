using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerSelectWidget : MonoBehaviour
{

  private GameManager.Robot[] OrderedRobots = { GameManager.Robot.Rosie, GameManager.Robot.Florence, GameManager.Robot.Hanako };

  public int PlayerID = -1;

  public int SelectedRobotIdx = 0;

  public BotSelectScreen SelectionController; 

  public Text PlayerIDLabel;
  public Text RobotNameLabel;
  public Text RobotDescLabel;
  public Text PrimaryAttackLabel;
  public Text SecondaryAttackLabel;
  public Image PlayerNumPanel;
  public GameObject OKPanel;

  // defines whether or not the player is locked in
  private bool _lockedIn = false;

  void Start()
  {
    UpdateSelection();
    // start disabled until activated by a player
    gameObject.SetActive(false);
  }

  public void UpdateSelection()
  {
    var selectedRobot = OrderedRobots[SelectedRobotIdx];
    PlayerIDLabel.text = "P" + (PlayerID + 1).ToString();
    PlayerNumPanel.color = GameManager.PlayerColors[PlayerID];
    RobotNameLabel.text = GameManager.RobotData[selectedRobot].Name;
    RobotDescLabel.text = GameManager.RobotData[selectedRobot].Description;
    PrimaryAttackLabel.text = GameManager.RobotData[selectedRobot].PrimaryAttack;
    SecondaryAttackLabel.text = GameManager.RobotData[selectedRobot].SecondaryAttack;
  }

  public void SelectRobot(int idx)
  {
    if (_lockedIn) return;
    // fancy calculation of positive modulo here, important
    SelectedRobotIdx = (idx + OrderedRobots.Length) % OrderedRobots.Length;
    Debug.Log(PlayerID + ", " + SelectedRobotIdx);
    UpdateSelection();
  }

  public void SelectNext()
  {
    SelectRobot(SelectedRobotIdx + 1);
  }

  public void SelectPrev()
  {
    SelectRobot(SelectedRobotIdx - 1);
  }

  public GameManager.Robot LockIn()
  {
    if (!_lockedIn)
    {
      // lock in
      _lockedIn = true;
      SelectionController.ReadyPlayerCount += 1;
      OKPanel.SetActive(true);
    }
    return OrderedRobots[SelectedRobotIdx];
  }

  public void UnLockIn()
  {
    if (_lockedIn)
    {
      _lockedIn = false;
      SelectionController.ReadyPlayerCount -= 1;
      OKPanel.SetActive(false);
    }
  }
}
