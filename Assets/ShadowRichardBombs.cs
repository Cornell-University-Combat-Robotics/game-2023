using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowRichardBombs : Action
{

  public GameObject BombPrefab;

  public override void Execute()
  {
    for (var i = 0; i < 5; i++)
    {
      var bomb = Instantiate(BombPrefab);
      bomb.transform.position = transform.position;
      bomb.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f);
    }
  }

}
