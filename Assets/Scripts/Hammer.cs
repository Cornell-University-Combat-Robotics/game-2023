using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Hammer : MonoBehaviour
{

    public int HammerForce = 1500;
    public int HammerTorqueNoise = 100;

    private Collider2D _collider;

    private void Start() {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
    }

    public void ToggleHammer(bool enabled) {
        print(enabled);
        _collider.enabled = enabled;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var otherBotMovement = other.GetComponent<BotMovement>();
        if (otherBotMovement)
        {
            var force = other.transform.position - transform.parent.position;
            force *= HammerForce;
            otherBotMovement.AddImpactForce(force);
            var torque = Random.Range(-1, 1) * HammerTorqueNoise;
            otherBotMovement.AddImpactTorque(torque);
        }
     }
}
