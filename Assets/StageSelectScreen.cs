using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StageSelectScreen : MonoBehaviour
{
  public StageSelectOption CurrentSelection;
  public Text StageName;

  void Start()
  {
    // init default selection
    CurrentSelection = GameObject.Find("Options").transform.GetChild(0).GetComponent<StageSelectOption>();
    CurrentSelection.Highlight(true);
    UpdateUI();
  }

  public void SelectRight(InputAction.CallbackContext ctx)
  {
    if (!ctx.performed) return;
    CurrentSelection.Highlight(false);
    CurrentSelection = CurrentSelection.Right;
    CurrentSelection.Highlight(true);
    UpdateUI();
  }

  public void SelectLeft(InputAction.CallbackContext ctx)
  {
    if (!ctx.performed) return;
    CurrentSelection.Highlight(false);
    CurrentSelection = CurrentSelection.Left;
    CurrentSelection.Highlight(true);
    UpdateUI();
  }

  public void Select(InputAction.CallbackContext ctx)
  {
    if (!ctx.performed) return;
    // tell game manager what's up
    GameManager.Instance.CurrentStage = CurrentSelection.Option;
    GameObject.Find("Canvas").GetComponent<MainMenuController>().ChangeState(MainMenuController.MenuState.BotSelect);
  }

  public void UpdateUI()
  {
    StageName.text = CurrentSelection.Option.ToString();
  }
}
