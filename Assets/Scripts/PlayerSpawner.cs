using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{

    // set up in editor, link robots to prefabs
    public GameObject RosiePrefab;
    public GameObject FlorencePrefab;
    public GameObject HanakoPrefab;
    public GameObject StevePrefab;
    public GameObject RichardPrefab;
    public GameObject MannyPrefab;
  public GameObject ShadowRichardPrefab;

    private Dictionary<GameManager.Robot, GameObject> robotPrefabs;
    // ... and so on. TODO: make this better.
    
    private void Awake() {
        // set up prefab dict
        robotPrefabs =
        new Dictionary<GameManager.Robot, GameObject> {
            {GameManager.Robot.Rosie, RosiePrefab},
            {GameManager.Robot.Florence, FlorencePrefab},  
            {GameManager.Robot.Hanako, HanakoPrefab},
            {GameManager.Robot.Steve, StevePrefab},
            {GameManager.Robot.Richard, RichardPrefab},
            {GameManager.Robot.Manny, MannyPrefab},
            {GameManager.Robot.ShadowRichard, ShadowRichardPrefab}
        };
    }

    private void Start() {
        var mainCamera = GameObject.Find("MainCamera").GetComponent<MultipleTargetCamera>();
        // spawn all players according to data
        foreach (var entry in GameManager.Instance.PlayerData)
        {
            var playerID = entry.Key;
            var config = entry.Value;
            var input = config.device;
            // spawn instance of correct robot
            // set up proper input device
            var robotPrefab = PlayerInput.Instantiate(robotPrefabs[config.robot], pairWithDevice: input);
            robotPrefab.GetComponent<BotStatus>().PlayerID = playerID;
            robotPrefab.transform.position = GameObject.Find("SpawnPoints").transform.GetChild(playerID).position;
            // give it a UI element
            var playerUIElement = GameObject.Find("PlayerUIs").transform.GetChild(playerID).GetComponent<PlayerUI>(); 
            playerUIElement.gameObject.SetActive(true);
            playerUIElement.Status = robotPrefab.GetComponent<BotStatus>();
            robotPrefab.GetComponent<BotStatus>().UI = playerUIElement;
            GameObject.Find("MatchController").GetComponent<MatchController>().RegisterPlayerAlive(playerID);
            // set it up to be tracked by the camera
            mainCamera.Targets.Add(robotPrefab.transform);
        }
    }
}
