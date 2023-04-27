using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
        public Sprite Sprite;

        public RobotDataEntry(string name, string description, string primaryAttack, string secondaryAttack, Sprite sprite)
        {
            Name = name;
            Description = description;
            PrimaryAttack = primaryAttack;
            SecondaryAttack = secondaryAttack;
            Sprite = sprite;
        }
    }

    // we need to set the sprites in the editor manually
    public Sprite RosieSprite;
    public Sprite FlorenceSprite;
    public Sprite SteveSprite;
    public Sprite HanakoSprite;

    public static Dictionary<Robot, RobotDataEntry> RobotData;

    // game manager singleton handles player data
    public static GameManager Instance;

    public Dictionary<int, PlayerConfig> PlayerData;

    public class PlayerConfig 
    {
        public Robot robot;
        public InputDevice device;

        public PlayerConfig(InputDevice input)
        {
            this.robot = Robot.Rosie;
            this.device = input;
        }
    }

    // return the number of players
    public int NumPlayers()
    {
        return PlayerData.Count;
    }

    // used to communicate that a player has been added
    // returns that player's ID
    public int AddPlayer(InputDevice input)
    {
        int id = NumPlayers();
        PlayerData.Add(id, new PlayerConfig(input));
        // activate that player's UI
        GameObject playerUI = GameObject.Find("PlayerUIs").transform.GetChild(id).gameObject;
        playerUI.SetActive(true);
        return id;
    }

    private void Awake()
    {
        Instance = this;
        PlayerData = new Dictionary<int, PlayerConfig>();
        // initialize robotdata
        RobotData = new Dictionary<Robot, RobotDataEntry>
        {
            {Robot.Rosie, new RobotDataEntry("Rosie", "Rosie Description", "H.Spinner", "Glaive", RosieSprite)},
            {Robot.Florence, new RobotDataEntry("Florence", "Florence Description", "Tri.Flipper", "Table Jump", FlorenceSprite)},
            {Robot.Steve, new RobotDataEntry("Steve", "Steve Description", "Mine", "Craft", SteveSprite)},
            {Robot.Hanako, new RobotDataEntry("Hanako", "Hanako Description", "V.Spinner", "EMP", HanakoSprite)}
        };

        DontDestroyOnLoad(gameObject);
    }

    // handle starting game from menu
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}