using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BotActions : MonoBehaviour
{
  public List<Action> Actions;

  private Dictionary<string, int> _inputToActionIdx = new Dictionary<string, int>(){
    {"Main Attack", 0},
    {"Secondary Attack", 1},
  };

  public void PerformAction(InputAction.CallbackContext ctx)
  {
    // perform the action corresponding to the input
    if (ctx.performed)
    {
      Debug.Log(ctx.action.name);
      Actions[_inputToActionIdx[ctx.action.name]].Execute();
    }
  }
}
