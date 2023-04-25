using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichardWeapon : Action
{

    [SerializeField]
    public Animator RichardAnimator;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Execute()
    {
        RichardAnimator.SetBool("Activate Weapon", true);
    }

    public override void Unexecute()
    {
        RichardAnimator.SetBool("Activate Weapon", false);
    }
}
