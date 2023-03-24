using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
  public abstract void Execute();

  public virtual void Unexecute()
  {
    // override this if the action does stuff when button released
    return;
  }
}
