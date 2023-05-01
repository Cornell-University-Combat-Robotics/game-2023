using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
  public BotStatus Status;
  public Image PlayerIcon;
  public Image PlayerColorPanel;
  public Slider HealthSlider;
  public Text PlayerIDText;

  public void Init(BotStatus playerStatus)
  {
    Status = playerStatus;
    playerStatus.UI = this;
  }

  public void UpdateUI()
  {
    HealthSlider.value = Status.Health / Status.MaxHealth;
    PlayerIDText.text = "P" + (Status.PlayerID + 1).ToString();
    PlayerColorPanel.color = GameManager.PlayerColors[Status.PlayerID];
    PlayerIcon.sprite = Status.GetComponent<SpriteRenderer>().sprite;
    // if dead, disable
    if (Status.Health <= 0)
    {
      gameObject.SetActive(false);
    }
  }
};
