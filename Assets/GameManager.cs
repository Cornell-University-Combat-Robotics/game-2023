using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // global constants

    public static readonly Color[] PlayerColors = {Color.red, Color.blue, Color.green, Color.yellow};

  public enum Stage
  {
    HLNR,
    TestBox,
    TestLabyrinth,
    MetalPipeWorld,
    LanceStage,
  }

  public Stage CurrentStage;

  // store data on all the robots
  public enum Robot
    {
        Rosie,
        Florence,
        Steve,
        Hanako,
        Richard,
        Manny
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
    public Sprite RichardSprite;

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
        return id;
    }

    private void Awake()
    {
        Instance = this;
        PlayerData = new Dictionary<int, PlayerConfig>();
        // initialize robotdata
        RobotData = new Dictionary<Robot, RobotDataEntry>
        {
            {Robot.Rosie, new RobotDataEntry("Rosie", "Horizontal spinner with a floral flourish. Rosie uses AR500 steel spinner to destroy opponents both close-up and long range.", "H.Spinner", "Glaive", RosieSprite)},
            {Robot.Florence, new RobotDataEntry("Florence", "Two wheeled tri-flipper floppy queen. Florence uses flippers to gain height over opponents.", "Tri.Flipper", "Table Jump", FlorenceSprite)},
            {Robot.Steve, new RobotDataEntry("Steve", "Fierce bot wielding two pickaxes inspired by a certain game about blocks. Steve's pickaxes pierce through everything.", "Mine", "Craft", SteveSprite)},
            {Robot.Hanako, new RobotDataEntry("Hanako", "Ghosty blue bot with four side-by-side vertical saws. Hanako keeps opponents close to their saws.", "V.Spinner", "Ghostly Warp", HanakoSprite)},
            {Robot.Richard, new RobotDataEntry("Richard", "Fiery orange striped vertical spinner. Richard channels the energy of an angry tiger", "V.Spinner", "Tiger trap", RichardSprite)},
            {Robot.Manny, new RobotDataEntry("Manny", "Ftiger", "Vhammerer", "ramp", RichardSprite)}
        };

        DontDestroyOnLoad(gameObject);
    }

    // handle starting game from menu
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        // back to menu
        SceneManager.LoadScene("MainMenu");
        // clear players
        PlayerData.Clear();
    }
}