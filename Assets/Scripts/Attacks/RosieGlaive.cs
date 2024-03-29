using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosieGlaive : Action
{

  // Reference to Rosie's weapon RigidBody component and joint, so we can detach it
  public Rigidbody2D Weapon;
  public WheelJoint2D Joint;


  // The force that the weapon launches at
  private float _launchForce = 600f;
  private float _launchTorque = 1000f;

  private bool _isAttached = true;

  public IEnumerator ReattachWeapon()
  {
    var camera = GameObject.Find("MainCamera").GetComponent<MultipleTargetCamera>();
    camera.Targets.Add(Weapon.transform);
    Weapon.GetComponent<Collider2D>().isTrigger = true;
    yield return new WaitForSeconds(0.05f);
    Weapon.GetComponent<Collider2D>().isTrigger = false;
    yield return new WaitForSeconds(3f);
    // try to return to rosie
    Weapon.transform.position = Joint.transform.position;
    Joint.connectedBody = Weapon;
    Weapon.gameObject.transform.localScale = new Vector2(1, 1);
    _isAttached = true;
    camera.Targets.Remove(Weapon.transform);
  }

  public override void Execute()
  {
    // only let this work if weapon is attached
    if (!_isAttached) return;
    // detach weapon from joint
    _isAttached = false;
    Weapon.gameObject.transform.localScale = new Vector2(2, 2);
    Joint.connectedBody = null;
    // set the hitbox
    Weapon.GetComponent<Spinner>().SpinnerActive = true;
    // give weapon some forward force and massive torque
    Weapon.drag = 0f;
    Weapon.angularDrag = 0f;
    Weapon.AddForce(_launchForce * Joint.transform.up);
    Weapon.AddTorque(_launchTorque);
    // start a coroutine to reattach
    StartCoroutine(ReattachWeapon());
  }
}
