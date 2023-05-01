using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
  public enum MenuState
  {
    BotSelect,
    StageSelect
  };

  public GameObject BotSelectRoot;
  public GameObject StageSelectRoot;

  private MenuState _currentState;

  public void ChangeState(MenuState newState)
  {
    switch (newState)
    {
      case MenuState.BotSelect:
        StageSelectRoot.SetActive(false);
        BotSelectRoot.SetActive(true);
        break;

      case MenuState.StageSelect:
        StageSelectRoot.SetActive(true);
        BotSelectRoot.SetActive(false);
        break;

    }
  }

  void Awake()
  {
    ChangeState(MenuState.StageSelect);
  }
}
