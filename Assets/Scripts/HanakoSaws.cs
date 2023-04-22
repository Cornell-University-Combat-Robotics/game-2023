using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanakoSaws : Action
{

    [SerializeField]
    public Animator HanakoAnimator;

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
        HanakoAnimator.SetBool("Activate Weapon", true);
    }

    public override void Unexecute()
    {
        HanakoAnimator.SetBool("Activate Weapon", false);
    }
}
