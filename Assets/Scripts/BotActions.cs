using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BotActions : MonoBehaviour
{
  public List<Action> Actions;

  public List<float> Cooldowns;

  private float[] _currentCooldowns;

  private Dictionary<string, int> _inputToActionIdx = new Dictionary<string, int>(){
    {"Main Attack", 0},
    {"Secondary Attack", 1},
  };

  void Start()
  {
    _currentCooldowns = new float[Cooldowns.Count];
    for (var i = 0; i < Cooldowns.Count; i++)
    {
      _currentCooldowns[i] = Cooldowns[i];
    }
  }

  void Update()
  {
    // update cooldowns
    for (var i = 0; i < _currentCooldowns.Length; i++)
    {
      _currentCooldowns[i] -= Time.deltaTime;
    }
    // Debug.Log(_currentCooldowns[1]);
  }

  public void PerformAction(InputAction.CallbackContext ctx)
  {
    // perform the action corresponding to the input
    if (ctx.performed)
    {
      // check cooldowns
      var actionIdx = _inputToActionIdx[ctx.action.name];
      if (_currentCooldowns[actionIdx] > 0) return;
      Debug.Log("Trying to execute");
      Actions[actionIdx].Execute();
      _currentCooldowns[actionIdx] = Cooldowns[actionIdx];
    }
    else if (ctx.canceled)
    {
      Actions[_inputToActionIdx[ctx.action.name]].Unexecute();
    }
  }
}
