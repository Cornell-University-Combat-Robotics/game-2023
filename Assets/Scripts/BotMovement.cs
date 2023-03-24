using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// We need to use UnityEngine.InputSystem namespace to handle input in this file
using UnityEngine.InputSystem;


[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class BotMovement : MonoBehaviour
{

  // Serialized fields. These are exposed to the editor
  [SerializeField]
  public float Acceleration = 5f; // default value defined here
  // // #TODO: Implement turning. Use the exposed turn speed field
  // // in FixedUpdate to apply turning to the game object through Rigidbody2D.
  // Decay for velocity over time
  [SerializeField]
  public float TurnSpeed = 0f;

  // Private fields.
  private Rigidbody2D _rigidBody; // reference to a rigidbody component
  private Vector2 _inputDirection; // the direction that the player is inputting
  private Vector2 _velocity; // the robot's current velocity
  private float _turningTimer; // how long the robot has been turning. used for beyblade mode switching
  private bool _controllable = true; // whether the robot is currently controllable

  // Start runs when the game object first begins to exist in the scene. 
  void Start()
  {
    // if we need to access another component attached to the game object, 
    // we can set it to a field here. 
    _rigidBody = GetComponent<Rigidbody2D>();
  }

  // toggles the bot between a controllable and uncontrollable state.
  public void ToggleControllable(bool controllable)
  {
    _controllable = controllable;
  }

  // Fixed update runs a fixed # of times per unit of time.
  // Used for handling physics interactions
  void FixedUpdate()
  {
    // fwd/backward froce
    _rigidBody.AddForce(transform.up * _inputDirection.y * Acceleration);
    // turning force
    // track how long we've been turning in place for beyblade mode
    if (Mathf.Abs(_inputDirection.x) > 0 && Mathf.Abs(_inputDirection.y) == 0)
      _turningTimer += Time.deltaTime;
    else
      _turningTimer = 0;
    _rigidBody.AddTorque(-1 
      * _inputDirection.x 
      * TurnSpeed 
      * (_turningTimer > 0.5f ? 3 : 1) // if turning for a while, beyblade mode
    );
  }

  // This function is hooked up to a Unity event, through the editor. Any time
  // an appropriate input event occurs, it is called.
  public void ReadInput(InputAction.CallbackContext ctx)
  {
    // This reads the current input direction as a Vector2, and sets it here
    // for use in FixedUpdate. 
    if (_controllable)
    {
      _inputDirection = ctx.ReadValue<Vector2>();
    }
    else
    {
      _inputDirection = Vector2.zero;
    }
  }

  public void AddImpactForce(Vector2 force) {
    _rigidBody.AddForce(force);
  }

  public void AddImpactTorque(float torque) {
    _rigidBody.AddTorque(torque);
  }
}
