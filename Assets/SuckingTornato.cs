using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckingTornato : MonoBehaviour
{

  public float TornadoForce = 800f;
  void OnTriggerStay2D(Collider2D other)
  {
    Debug.Log("SUCKKKK");
    var otherBody = other.GetComponent<Rigidbody2D>();
    if (otherBody)
    {
      var force = transform.position - other.transform.position;
      otherBody.AddForce(force * TornadoForce * Time.deltaTime);
    }
  }
}
