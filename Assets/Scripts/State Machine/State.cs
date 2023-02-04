using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual IEnumerator Start() 
    {
        yield break;
    }
    public virtual IEnumerator Update() 
    {
        yield break;
    }
    public virtual IEnumerator FollowPlayer() 
    {
        yield break;
    }
    public virtual IEnumerator GotoPoint()
    {
        yield break;
    }
}
