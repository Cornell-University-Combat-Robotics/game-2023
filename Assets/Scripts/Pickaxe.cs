using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Pickaxe : MonoBehaviour
{

    public int PickaxeForce = 1500;
    public int PickaxeDamage = 25;
    public int PickaxeTorqueNoise = 100;

    private bool pickaxeEnabled = false;

    private Collider2D _collider;

    private void Start() {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
    }

    public void TogglePickaxe(bool enabled) {
        print("Togglgin pciks");
        _collider.enabled = enabled;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("PICKED");
        var otherBotMovement = other.GetComponent<BotMovement>();
        if (otherBotMovement)
        {
            var force = other.transform.position - transform.parent.position;
            force *= PickaxeForce;
            otherBotMovement.AddImpactForce(force);
            var torque = Random.Range(-1, 1) * PickaxeTorqueNoise;
            otherBotMovement.AddImpactTorque(torque);
        }
        // deal damage
        var otherBotStatus = other.GetComponent<BotStatus>();
        if (otherBotStatus)
        {
        otherBotStatus.TakeDamage(PickaxeDamage);
        }
     }
}
