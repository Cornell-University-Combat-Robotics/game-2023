using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichardTornado : Action
{
  public GameObject Effects;
  private PolygonCollider2D _collider;

  void Start()
  {
    _collider = GetComponent<PolygonCollider2D>();
    _collider.enabled = false;
    Effects.SetActive(false);
  }

  public override void Execute()
  {
    Debug.Log("TEST");
    Effects.SetActive(true);
    _collider.enabled = true;
  }

  public override void Unexecute()
  {
    Debug.Log("DONE");
    Effects.SetActive(false);
    _collider.enabled = false;
  }

  public float TornadoForce = 800f;
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
