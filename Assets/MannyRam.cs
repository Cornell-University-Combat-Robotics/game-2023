using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannyRam : Action
{
    private Collider2D _collider;
    public ParticleSystem RamEffect;

    public void ToggleRam(bool enabled) {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = enabled;
    }

    IEnumerator Ram() {
        // delay the pick drop w/ animation

        ToggleRam(true);
        
        // play effect
        RamEffect.Play();
        yield return new WaitForSeconds(1f);

        ToggleRam(false);
        
    }

    public override void Execute() {
    Debug.Log("Manny rammed");
        var movement = transform.parent.gameObject.GetComponent<BotMovement>();
        var direction = transform.TransformDirection(2000 * Vector2.up);
        movement.AddImpactForce(direction);
            
        StartCoroutine(Ram());
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var otherBotMovement = other.GetComponent<BotMovement>();
        if (otherBotMovement)
        {
            
            var force = other.transform.position - transform.parent.position;
            force *= 2000;
            otherBotMovement.AddImpactForce(force);
      var torque = Random.Range(-1, 1) * 10000f;
            otherBotMovement.AddImpactTorque(torque);
        }

    var otherBotStatus = other.GetComponent<BotStatus>();
        if (otherBotStatus)
        {
        otherBotStatus.TakeDamage(10);
        }


    }




    // Start is called before the first frame update
    void Start()
    {
      ToggleRam(false);   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
