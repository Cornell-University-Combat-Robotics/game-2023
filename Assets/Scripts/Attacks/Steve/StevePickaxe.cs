using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StevePickaxe : Action
{

    // references to pickaxes
    public List<Pickaxe> Pickaxes;

    private Animator _animator;

    private void Start() {
        _animator = transform.parent.GetComponent<Animator>();
    }

    public override void Execute()

    {
        Debug.Log("piercing attack");
        _animator.SetBool("Piercing", true);
        StartCoroutine(TogglePickaxes());
    }

    IEnumerator TogglePickaxes()
    {
        foreach (Pickaxe pickaxe in Pickaxes)
        {
            pickaxe.TogglePickaxe(true);
        }
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
