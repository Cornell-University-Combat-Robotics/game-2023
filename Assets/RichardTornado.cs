using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichardTornado : Action
{
  public float TornadoForce = 800f;
  public ParticleSystem Effects;
  private Collider2D _collider;

  void Start()
  {
    _collider = GetComponent<Collider2D>();
    _collider.enabled = false;
    Effects.Stop();
  }

  public override void Execute()
  {
    Effects.Play();
    _collider.enabled = true;
  }

  public override void Unexecute()
  {
    Effects.Stop();
    _collider.enabled = false;
  }

  public void OnTriggerStay2D(Collider2D other)
  {
    var otherBody = other.GetComponent<Rigidbody2D>();
    if (otherBody)
    {
      var force = transform.position - other.transform.position;
      otherBody.AddForce(force * TornadoForce * Time.deltaTime);
    }
  }
}
