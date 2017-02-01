using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public State(Transform transform)
    {
        this.position = transform.position;
        this.rotation = transform.rotation;
        this.scale = transform.localScale;
    }
}

public class RewindHandler : Singleton<RewindHandler> {

    public void FlipRewind()
    {
        StateHistory[] shs = FindObjectsOfType<StateHistory>();
        Debug.Log("SHS: " + shs.Length);
        foreach (StateHistory s in shs)
        {
            s.FlipRewind();
        }
    }
}
