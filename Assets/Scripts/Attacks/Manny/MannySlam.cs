using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannySlam : Action
{

  public ParticleSystem HammerEffects;
    // references to hammers
    public List<Hammer> Hammers;

    private Animator _animator;

    private void Start() {
        _animator = transform.parent.GetComponent<Animator>();
    }

    public override void Execute()

    {
        _animator.SetBool("Slamming", true);
        StartCoroutine(ToggleHammers());
    }

    IEnumerator ToggleHammers()
    {
    yield return new WaitForSeconds(0.25f);
        foreach (Hammer hammer in Hammers)
        {
            hammer.ToggleHammer(true);
        }
    HammerEffects.Play();
        yield return new WaitForFixedUpdate();
        foreach (Hammer hammer in Hammers)
        {
            hammer.ToggleHammer(false);
        }
    }

    public override void Unexecute()
    {
        _animator.SetBool("Slamming", false);
    }

}
