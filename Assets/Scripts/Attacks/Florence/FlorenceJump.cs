using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorenceJump : Action
{

    private Animator _animator;

    private void Start() {
        _animator = transform.parent.GetComponent<Animator>();
    }

    public override void Execute()
    {
        _animator.SetTrigger("Jump");
    }

}
