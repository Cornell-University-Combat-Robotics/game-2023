using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceFlip : Action
{

    // references to flippers
    public List<Flipper> Flippers;

    private Animator _animator;

    private void Start() {
        _animator = transform.parent.GetComponent<Animator>();
    }

    public override void Execute()
    {
        _animator.SetBool("Flipping", true);
        StartCoroutine(ToggleFlippers());
    }

    IEnumerator ToggleFlippers()
    {
        foreach (Flipper flipper in Flippers)
        {
            flipper.ToggleFlipper(true);
        }
        yield return new WaitForFixedUpdate();
        foreach (Flipper flipper in Flippers)
        {
            flipper.ToggleFlipper(false);
        }
    }

    public override void Unexecute()
    {
        _animator.SetBool("Flipping", false);
    }

}
