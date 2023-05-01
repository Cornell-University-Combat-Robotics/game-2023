using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanakoBlink : Action
{

  public ParticleSystem Effects;
  public int BlinkDist = 10;

  public override void Execute()
  {
    Effects.Play();
    RaycastHit hit;
    // Does the ray intersect any objects excluding the player layer
    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector2.up), out hit, BlinkDist))
    {
      transform.parent.position = hit.point;
    }
    else
    {
      transform.parent.position += transform.TransformDirection(Vector2.up) * BlinkDist;
    }
  }

}
