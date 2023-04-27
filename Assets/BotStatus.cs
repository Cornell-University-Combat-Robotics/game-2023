using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BotStatus : MonoBehaviour
{
  public PlayerUI UI;

  public int PlayerID = -1;

  [SerializeField]
  public float MaxHealth = 100f;
  public float Health { get; private set; }

  private MatchController _matchController;

  void Start()
  {
    Health = MaxHealth;
    UI.UpdateUI();
    _matchController = GameObject.Find("MatchController").GetComponent<MatchController>();
  }

  public void TakeDamage(float damage)
  {
    Health -= damage;

    if (IsDead())
    {
      // kill the bot
      GetComponent<SpriteRenderer>().color = Color.grey;
      GetComponent<PlayerInput>().enabled = false;
      _matchController.RegisterPlayerDead(PlayerID);
      GameObject.Find("MainCamera").GetComponent<MultipleTargetCamera>().Targets.Remove(gameObject.transform);
    }
    UI.UpdateUI();
  }

  public void Heal(float health)
  {
    Health += health;
  }

  public bool IsDead()
  {
    return Health <= 0;
  }
}
