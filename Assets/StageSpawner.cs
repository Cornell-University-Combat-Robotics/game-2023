using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{

  [SerializeField]
  public GameObject HLNRPrefab;
  public GameObject TestBoxPrefab;

  public Dictionary<GameManager.Stage, GameObject> StageToPrefab;

  void Awake()
  {
    StageToPrefab = new Dictionary<GameManager.Stage, GameObject>()
    {
            { GameManager.Stage.HLNR, HLNRPrefab },
            { GameManager.Stage.TestBox, TestBoxPrefab}
    };
    Instantiate(StageToPrefab[GameManager.Instance.CurrentStage]);
  }
}
