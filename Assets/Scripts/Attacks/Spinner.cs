using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Spinner : MonoBehaviour
{

  public float Damage = 5f;// damage per contact with spinner
  public float Knockback = 1f;
  public ParticleSystem Sparks;

  public bool SpinnerActive = false;

  private Collider2D _collider;

    private void Start() {
        _collider = GetComponent<Collider2D>();
    }



  private void OnCollisionEnter2D(Collision2D other)
  {
    // play sparks effect
    if (SpinnerActive)
    {
      Sparks.transform.position = (other.transform.position + transform.position) / 2;
      Sparks.Play();
      // check if there's a bot to damage
      var botStatus = other.gameObject.GetComponent<BotStatus>();
      if (botStatus)
      {
        botStatus.TakeDamage(Damage);
      }
      // check if there's a body to move
      var body = other.gameObject.GetComponent<Rigidbody2D>();
      if (body)
      {
        body.AddForce((other.transform.position - transform.position) * Knockback * 800f);
      }
    }
  }

}
