using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichardWeapon : Action
{

    [SerializeField]
    public Animator Richard;
    public Spinner RichardSpinner;


    public override void Execute()
    {
        RichardSpinner.SpinnerActive = true;
        Richard.SetBool("Activate Weapon", true);
        
    }

    public override void Unexecute()
    {
        RichardSpinner.SpinnerActive = false;
        Richard.SetBool("Activate Weapon", false);
        
    }
}
