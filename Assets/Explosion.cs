using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    var otherStatus = other.GetComponent<BotStatus>();
    if (otherStatus)
    {
      otherStatus.TakeDamage(25);
    }
    var otherBody = other.GetComponent<Rigidbody2D>();
    if (otherBody)
    {
      var force = other.transform.position - transform.position;
      force *= 10000f;
      otherBody.AddForce(force);
    }
  }
}
