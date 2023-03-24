using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorenceJump : Action
{

    private BotMovement _botMovement;
    private Animator _animator;
    private Collider2D _florenceCollider; // to disable collisions while "jumping"

    private void Start() {
        _botMovement = transform.parent.GetComponent<BotMovement>();
        _animator = transform.parent.GetComponent<Animator>();
        _florenceCollider = transform.parent.GetComponent<Collider2D>();
    }

    IEnumerator Jump() {
        _animator.SetTrigger("Jump");
        _botMovement.AddImpactForce(_botMovement.transform.forward * 10f);
        _botMovement.ToggleControllable(false);
        _florenceCollider.isTrigger = true;
        yield return new WaitForSeconds(0.4f);
        _botMovement.ToggleControllable(true);
        _florenceCollider.isTrigger = false;
        // emit the shockwave damage here
    }

    public override void Execute()
    {
        StartCoroutine(Jump());
    }

}
