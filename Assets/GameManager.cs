using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // global constants

    public static readonly Color[] PlayerColors = {Color.red, Color.blue, Color.green, Color.yellow};

    // store data on all the robots
    public enum Robot
    {
        Rosie,
        Florence,
        Steve,
        Hanako
    }

    public struct RobotDataEntry {
        public string Name;
        public string Description;
        public string PrimaryAttack;
        public string SecondaryAttack;

        public RobotDataEntry(string name, string description, string primaryAttack, string secondaryAttack)
        {
            Name = name;
            Description = description;
            PrimaryAttack = primaryAttack;
            SecondaryAttack = secondaryAttack;
        }
    }

    public static readonly Dictionary<Robot, RobotDataEntry> RobotData = new Dictionary<Robot, RobotDataEntry>
    {
        {Robot.Rosie, new RobotDataEntry("Rosie", "Rosie Description", "H.Spinner", "Glaive")},
        {Robot.Florence, new RobotDataEntry("Florence", "Florence Description", "Tri.Flipper", "Table Jump")},
        {Robot.Steve, new RobotDataEntry("Steve", "Steve Description", "Mine", "Craft")},
        {Robot.Hanako, new RobotDataEntry("Hanako", "Hanako Description", "V.Spinner", "EMP")}
    };

    // game manager singleton handles player data
    public static GameManager Instance;

    public Dictionary<int, PlayerConfig> PlayerData;

    public class PlayerConfig 
    {
        public Robot robot;

        public PlayerConfig()
        {
            this.robot = Robot.Rosie;
        }
    }

    // return the number of players
    public int NumPlayers()
    {
        return PlayerData.Count;
    }

    // used to communicate that a player has been added
    // returns that player's ID
    public int AddPlayer()
    {
        int id = NumPlayers();
        PlayerData.Add(id, new PlayerConfig());
        // activate that player's UI
        GameObject playerUI = GameObject.Find("PlayerUIs").transform.GetChild(id).gameObject;
        playerUI.SetActive(true);
        return id;
    }

    private void Awake()
    {
        Instance = this;
        PlayerData = new Dictionary<int, PlayerConfig>();
        DontDestroyOnLoad(gameObject);
    }

    // handle starting game from menu
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}