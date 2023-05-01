using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This object is created by the player input manager,
// which then handles spawning the player's prefab
// across scenes. 
public class MenuPlayerManager : MonoBehaviour
{
  public int PlayerID {get; private set;}

  private PlayerSelectWidget _widget;

  private void Awake() {
    // get the correct input
    // var input = InputSystem.devices[InputSystem.devices.Count - 1];
    var input = GetComponent<PlayerInput>().devices[0];
    // on spawn, configure ID based on number of players joined
    PlayerID = GameManager.Instance.AddPlayer(input);
    Debug.Log(input);
    // get refernce to the proper UI widget
    _widget = GameObject.Find("PlayerUIs").transform.GetChild(PlayerID).GetComponent<PlayerSelectWidget>();
    _widget.gameObject.SetActive(true);
  }

  // define behavior for robot selection

  public void SelectNext(InputAction.CallbackContext ctx)
  {
    if (ctx.performed)
      _widget.SelectNext();
  }

  public void SelectPrev(InputAction.CallbackContext ctx)
  {
    if (ctx.performed)
      _widget.SelectPrev();
  }

  public void LockIn(InputAction.CallbackContext ctx)
  {
    if (ctx.performed)
      // lock in selection
      GameManager.Instance.PlayerData[PlayerID].robot = _widget.LockIn();
  }

  public void UnLockIn(InputAction.CallbackContext ctx)
  {
    if (ctx.performed)
      // un-lock in selection
      _widget.UnLockIn();
  }

}
