using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpinner : Action
{

  public WheelJoint2D SpinnerMotor;
  public Spinner Spinner;
  public float SpinnerSpeed = 2000f;

  private float _targetSpeed = 0f;

  public override void Execute()
  {
    _targetSpeed = SpinnerSpeed;
    Spinner.SpinnerActive = true;
  }

  public void FixedUpdate()
  {
    // update motor speed
    var motor = SpinnerMotor.motor;
    motor.motorSpeed = Mathf.Lerp(motor.motorSpeed, _targetSpeed, 0.1f);
    SpinnerMotor.motor = motor;
  }

  public override void Unexecute()
  {
    _targetSpeed = 0f;
    Spinner.SpinnerActive = false;
  }
}
