using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : Action
{

  private Collider2D _collider;

  private void Start() {
    _collider = GetComponent<Collider2D>();
  }

  public override void Execute()
  {
    Debug.Log("Hammer Attack");
  }
}
