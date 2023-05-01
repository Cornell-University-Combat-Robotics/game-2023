using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StevePierce : Action
{

    // references to pickaxes
    public List<Pickaxe> Pickaxes;

    public ParticleSystem PierceEffect;

    private Animator _animator;

    private void Start() {
        _animator = transform.parent.GetComponent<Animator>();
    }

    public override void Execute()

    {
        StartCoroutine(TogglePickaxes());
        _animator.SetBool("Piercing", true);
    }

    IEnumerator TogglePickaxes()
    {
        // delay the pick drop w/ animation
        yield return new WaitForSeconds(0.4f);
        foreach (Pickaxe pickaxe in Pickaxes)
        {
            pickaxe.TogglePickaxe(true);
        }
        // play effect
        PierceEffect.Play();
        yield return new WaitForFixedUpdate();
        foreach (Pickaxe pickaxe in Pickaxes)
        {
            pickaxe.TogglePickaxe(false);
        }
    }

    public override void Unexecute()
    {
        _animator.SetBool("Piercing", false);
    }

}
