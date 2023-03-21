using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : Action
{

  private BotMovement _botMovement;

  public int DashForce = 300;

  private void Start() {
    _botMovement = transform.parent.GetComponent<BotMovement>();
  }

  public override void Execute()
  {
    _botMovement.AddImpactForce(_botMovement.gameObject.transform.up * DashForce);
    Debug.Log("Pew pew");
  }
}
