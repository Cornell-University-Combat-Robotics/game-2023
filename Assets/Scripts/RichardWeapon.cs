using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichardWeapon : Action
{

    [SerializeField]
    public Animator Richard;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Hello");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Execute()
    {
        Debug.Log("Activating weapon");
        Richard.SetBool("Activate Weapon", true);
        
    }

    public override void Unexecute()
    {
        Debug.Log("Deactivating weapon");
        Richard.SetBool("Activate Weapon", false);
        
    }
}
