using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    // set up in editor, link robots to prefabs
    public GameObject RosiePrefab;
    public GameObject FlorencePrefab;
    public GameObject HanakoPrefab;
    public GameObject StevePrefab;

    private Dictionary<GameManager.Robot, GameObject> robotPrefabs;
    // ... and so on. TODO: make this better.
    
    private void Awake() {
        // sert up prefab dict
        robotPrefabs =
        new Dictionary<GameManager.Robot, GameObject> {
            {GameManager.Robot.Rosie, RosiePrefab},
            {GameManager.Robot.Florence, FlorencePrefab},  
            {GameManager.Robot.Hanako, HanakoPrefab},          
            {GameManager.Robot.Steve, StevePrefab}          
        };
    }

    private void Start() {
        var mainCamera = GameObject.Find("MainCamera").GetComponent<MultipleTargetCamera>();
        // spawn all players according to data
        foreach (var entry in GameManager.Instance.PlayerData)
        {
      var playerID = entry.Key;
            var config = entry.Value;
            // spawn instance of correct robot
            var robotPrefab = Instantiate(robotPrefabs[config.robot]);
      robotPrefab.transform.position = GameObject.Find("SpawnPoints").transform.GetChild(playerID).position;
            // set it up to be tracked by the camera
            mainCamera.Targets.Add(robotPrefab.transform);
        }
    }
}
