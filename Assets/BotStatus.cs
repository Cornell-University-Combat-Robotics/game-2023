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

  void Start()
  {
    Health = MaxHealth;
    UI.UpdateUI();
  }

  public void TakeDamage(float damage)
  {
    Health -= damage;
    // update UI
    UI.UpdateUI();

    if (IsDead())
    {
      // kill the bot
      GetComponent<SpriteRenderer>().color = Color.grey;
      GetComponent<PlayerInput>().enabled = false;
    }
  }

  public void Heal(float health)
  {
    Health += health;
  }

  public bool IsDead()
  {
    return Health < 0;
  }
}
