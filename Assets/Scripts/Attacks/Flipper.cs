using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Flipper : MonoBehaviour
{

  public int FlipperDamage = 10;
  public int FlipperForce = 1500;
  public int FlipperTorqueNoise = 100;

  private Collider2D _collider;

  private void Start()
  {
    _collider = GetComponent<Collider2D>();
    _collider.enabled = false;
  }

  public void ToggleFlipper(bool enabled)
  {
    _collider.enabled = enabled;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    var otherBotMovement = other.GetComponent<BotMovement>();
    if (otherBotMovement)
    {
      var force = other.transform.position - transform.parent.position;
      force *= FlipperForce;
      otherBotMovement.AddImpactForce(force);
      var torque = Random.Range(-1, 1) * FlipperTorqueNoise;
      otherBotMovement.AddImpactTorque(torque);
    }
    // deal damage
    var otherBotStatus = other.GetComponent<BotStatus>();
    if (otherBotStatus)
    {
      otherBotStatus.TakeDamage(FlipperDamage);
    }
  }
}
