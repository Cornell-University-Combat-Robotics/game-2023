using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanakoSaws : Action
{

    [SerializeField]
    public Animator HanakoAnimator;
  public Spinner Saws;

    public override void Execute()
    {
    Saws.SpinnerActive = true;
        HanakoAnimator.SetBool("Activate Weapon", true);
    }

    public override void Unexecute()
    {
    Saws.SpinnerActive = false;
        HanakoAnimator.SetBool("Activate Weapon", false);
    }
}
