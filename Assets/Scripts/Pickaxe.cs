using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Pickaxe : MonoBehaviour
{

    public int PickaxeForce = 1500;
    public int PickaxeTorqueNoise = 100;

    private Collider2D _collider;

    private void Start() {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
    }

    public void TogglePickaxe(bool enabled) {
        print(enabled);
        _collider.enabled = enabled;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var otherBotMovement = other.GetComponent<BotMovement>();
        if (otherBotMovement)
        {
            var force = other.transform.position - transform.parent.position;
            force *= PickaxeForce;
            otherBotMovement.AddImpactForce(force);
            var torque = Random.Range(-1, 1) * PickaxeTorqueNoise;
            otherBotMovement.AddImpactTorque(torque);
        }
     }
}
