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
    Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * BlinkDist, Color.green, 1, depthTest:false);
    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), BlinkDist);
    if (hit.collider != null)
    {
      Debug.Log(hit.collider);
      transform.parent.position = hit.point;
    }
    else
    {
      transform.parent.position += transform.TransformDirection(Vector2.up) * BlinkDist;
    }
  }

}
