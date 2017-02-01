using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public float speed;

    StateHistory history;

    bool rewind = false;

	void Start ()
    {
        history = this.GetComponent<StateHistory>();   
	}
	
	void Update ()
    {
        this.transform.Translate(transform.right * speed * Time.deltaTime * Input.GetAxis("HorizontalLeft"));

        if (Input.GetButtonDown("RB"))
        {
            rewind = !rewind;
            if (history)
            {
                history.FlipRewind();
            }
            Debug.Log("Rewind Hit");
        }

        if (history && rewind)
        {
            Debug.Log("Processing Queue");
            State s = history.GetLastState();
            if (s != null)
            {
                this.transform.position = s.position;
                this.transform.rotation = s.rotation;
                this.transform.localScale = s.scale;
            }
            else
            {
                rewind = !rewind;
                if (history)
                {
                    history.FlipRewind();
                }
            }
        }
	}
}
