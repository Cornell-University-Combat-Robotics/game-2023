using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : Action
{

  private BotMovement _botMovement;

  private void Start() {
    _botMovement = transform.parent.GetComponent<BotMovement>();
  }

  public override void Execute()
  {
    _botMovement.AddImpactForce(new Vector2(0, 5));
    Debug.Log("Pew pew");
  }
}
