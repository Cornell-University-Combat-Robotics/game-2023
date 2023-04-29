using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteveBombSpawner : Action
{

  [SerializeField]
  public GameObject BombPrefab;

  public override void Execute()
  {
    var prefab = Instantiate(BombPrefab);
    prefab.transform.position = transform.position;
  }
}
