using UnityEngine;
using System.Collections.Generic;


public class StateHistory : MonoBehaviour
{

    public int framesToHold;

    LinkedList<State> stateList;

    bool rewind = false;

    public int stateCount;

	void Start ()
    {
        stateList = new LinkedList<State>();
        stateCount = 0;
	}
	
	
	void Update ()
    {
        // if we are rewinding, stop adding new states
        if (!rewind)
        {
            stateList.AddLast(new State(this.transform));
            stateCount++;

            if (stateList.Count > framesToHold)
            {
                stateList.RemoveFirst();
                stateCount--;
            }
        }
        else
        {
            ProcessRewind();
        }
        
	}

    void ProcessRewind()
    {

        State s = GetLastState();
        if (s != null)
        {
            this.transform.position = s.position;
            this.transform.rotation = s.rotation;
            this.transform.localScale = s.scale;
        }
        else
        {
            rewind = !rewind;
            Debug.Log("End of states");
        }
    }

    public void FlipRewind()
    {
        rewind = !rewind;
        if (rewind)
        {
            stateList.RemoveLast();
            stateCount--;
        }
    }

    public State GetLastState()
    {
        if (stateList.Count <= 0)
        {
            stateCount = 0;
            return null;
        }
        State s = stateList.Last.Value;
        stateList.RemoveLast();
        stateCount--;

        return s;
    }
}
